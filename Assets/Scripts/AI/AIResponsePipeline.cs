using System;
using System.Threading.Tasks;
using UnityEngine;

public class AIResponsePipeline
{
    private static AIResponsePipeline _instance;
    public static AIResponsePipeline Instance
    {
        get
        {
            if (_instance == null)
                _instance = new AIResponsePipeline();
            return _instance;
        }
    }

    private InputClassifier inputClassifier = new InputClassifier();
    private IntentClassifierAPI intentClassifier = new IntentClassifierAPI();
    private AIResponseBuilder builder = new AIResponseBuilder();
    private AIRequestManager aiManager = new AIRequestManager();

    private AIResponsePipeline() { }

    public async Task<string> Process(
    NPCProfile profile,
    DialogueNode node,
    DialogueContext context,
    string playerInput)
    {
        try
        {
            // 1️ 1차 차단 필터
            if (inputClassifier.IsBlocked(playerInput))
                return "그런 질문에는 답하지 않겠습니다.";

            // 2️ 의도 분류
            IntentType intent = await intentClassifier.Classify(playerInput);

            //Debug.Log($"[AIResponsePipeline] Player input intent: {intent} ({intent.GetDescription()})");

            // 3️ IN_WORLD 아닌 경우 회피 처리
            switch (intent)
            {
                case IntentType.META:
                    return "그런 질문에는 답하지 않겠습니다."; // 시스템 관련 질문
                case IntentType.NOISE:
                    return "..."; // 무의미한 잡음
                case IntentType.ACCUSATION:
                    context.SetFlag("Accused");
                    context.AddTrust(-1);
                    playerInput = " - [NPC를 의심하거나 범죄와 관련해 지목하는 발언] npc 성격에 맞게 회피성 멘트를 생성해주세요"; // 의심/지목 발언
                    break;
                case IntentType.IN_WORLD:
                    break; // 정상 대화, AI 호출
            }

            // 4️ 프롬프트 생성
            string fullPrompt = builder.BuildPrompt(
                profile,
                node,
                context,
                playerInput
            );

            // 5️ AI 호출
            string response = await aiManager.Generate(fullPrompt, playerInput);

            // 6️ 대화 기록 저장
            context.AddHistory(playerInput, response);

            // 7️ Node 기반 신뢰도 변화 적용
            context.AddTrust(node.trustDelta);

            return response;
        }
        catch (Exception e)
        {
            Debug.LogError($"[AIResponsePipeline] 예외 발생: {e}");
            return "생각을 정리 중입니다...";
        }
    }
}