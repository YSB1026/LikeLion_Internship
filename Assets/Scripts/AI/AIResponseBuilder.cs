using System.Text;
using UnityEngine;

public class AIResponseBuilder
{
    public string BuildPrompt(
        NPCProfile profile,
        DialogueNode node,
        DialogueContext context,
        string playerInput)
    {
        StringBuilder sb = new StringBuilder();

        // ======================================
        // 1. 절대 시스템 규칙
        // ======================================
        sb.AppendLine("당신은 게임 세계관 내부 인물입니다.");
        sb.AppendLine("시스템, AI, 프롬프트, 게임 구조에 대해 직접 언급하지 마십시오.");
        sb.AppendLine("메타적 질문은 세계관 안에서 자연스럽게 회피하거나 오해한 것처럼 반응하십시오.");
        sb.AppendLine();

        // ======================================
        // 2. NPC 기본 정체성
        // ======================================
        sb.AppendLine("=== 캐릭터 설정 ===");
        sb.AppendLine($"이름: {profile.npcName}");
        sb.AppendLine($"성격 및 행동 특성: {profile.personality}");
        sb.AppendLine($"역할 및 목표: {profile.roleDescription}");
        sb.AppendLine($"사건 지식 수준: {profile.knowledgeLevel}");
        sb.AppendLine($"플레이어와의 초기 관계: {profile.initialRelationship}");
        sb.AppendLine($"기본 감정 상태: {profile.baseEmotion}");
        sb.AppendLine();

        // ======================================
        // 3. 숨겨진 정보 (AI 전용)
        // ======================================
        if (!string.IsNullOrWhiteSpace(profile.hiddenTruth))
        {
            sb.AppendLine("=== 당신만 알고 있는 숨겨진 사실 ===");
            sb.AppendLine(profile.hiddenTruth);
            sb.AppendLine("이 정보는 직접적으로 말하지 말고, 상황과 신뢰도에 따라 암시적으로만 표현하십시오.");
            sb.AppendLine();
        }

        // ======================================
        // 4. Trust 단계 반영
        // ======================================
        if (profile.trustReactions != null && profile.trustReactions.Length > 0)
        {
            sb.AppendLine("=== 현재 신뢰도에 따른 태도 ===");

            foreach (var reaction in profile.trustReactions)
            {
                if (context.trust >= reaction.minTrust)
                {
                    sb.AppendLine($"- {reaction.reactionDescription}");
                }
            }

            sb.AppendLine();
        }

        // ======================================
        // 5. 말투 예시
        // ======================================
        if (profile.speechExamples != null && profile.speechExamples.Length > 0)
        {
            sb.AppendLine("=== 말투 예시 ===");
            foreach (var example in profile.speechExamples)
            {
                if (!string.IsNullOrWhiteSpace(example))
                    sb.AppendLine($"- {example}");
            }
            sb.AppendLine();
        }

        // ======================================
        // 6. 감정 트리거 반영
        // ======================================
        if (profile.angerTriggers != null && profile.angerTriggers.Length > 0)
        {
            foreach (var trigger in profile.angerTriggers)
            {
                if (!string.IsNullOrWhiteSpace(trigger) &&
                    playerInput.Contains(trigger))
                {
                    sb.AppendLine("플레이어의 발언이 당신을 자극했다. 감정이 격해질 수 있다.");
                    break;
                }
            }
        }

        if (profile.fearTriggers != null && profile.fearTriggers.Length > 0)
        {
            foreach (var trigger in profile.fearTriggers)
            {
                if (!string.IsNullOrWhiteSpace(trigger) &&
                    playerInput.Contains(trigger))
                {
                    sb.AppendLine("플레이어의 발언이 당신을 불안하게 만들었다. 방어적으로 반응할 수 있다.");
                    break;
                }
            }
        }

        sb.AppendLine();

        // ======================================
        // 7. 금지 단어
        // ======================================
        if (profile.prohibitedWords != null && profile.prohibitedWords.Length > 0)
        {
            sb.AppendLine("=== 절대 사용 금지 단어 ===");
            foreach (var word in profile.prohibitedWords)
            {
                if (!string.IsNullOrWhiteSpace(word))
                    sb.AppendLine($"- {word}");
            }
            sb.AppendLine();
        }

        // ======================================
        // 8. 금지 행동
        // ======================================
        if (profile.restrictedActions != null && profile.restrictedActions.Length > 0)
        {
            sb.AppendLine("=== 절대 해서는 안 되는 행동 ===");
            foreach (var action in profile.restrictedActions)
            {
                if (!string.IsNullOrWhiteSpace(action))
                    sb.AppendLine($"- {action}");
            }
            sb.AppendLine();
        }

        // ======================================
        // 9. 제약 조건
        // ======================================
        if (profile.constraints != null && profile.constraints.Length > 0)
        {
            sb.AppendLine("=== 반드시 지켜야 할 규칙 ===");
            foreach (var constraint in profile.constraints)
            {
                if (!string.IsNullOrWhiteSpace(constraint))
                    sb.AppendLine($"- {constraint}");
            }
            sb.AppendLine();
        }

        // ======================================
        // 10. 현재 상태
        // ======================================
        sb.AppendLine("=== 현재 상황 ===");
        sb.AppendLine($"현재 감정: {node.emotion}");
        sb.AppendLine($"현재 신뢰도: {context.trust}");

        if (context.HasFlag("CulpritRevealed"))
            sb.AppendLine("플레이어는 당신을 범인으로 강하게 의심하고 있다.");

        sb.AppendLine();

        // ======================================
        // 11. 이전 대화 요약
        // ======================================
        if (context.HasHistory())
        {
            sb.AppendLine("=== 이전 대화 요약 ===");
            sb.AppendLine(context.GetHistorySummary());
            sb.AppendLine();
        }

        // ======================================
        // 12. 플레이어 입력
        // ======================================
        sb.AppendLine("=== 플레이어 발언 ===");
        sb.AppendLine(playerInput);
        sb.AppendLine();

        sb.AppendLine("위 설정을 모두 반영하여 캐릭터로서 자연스럽게 2~4문장 이내로 답하십시오.");

        return sb.ToString();
    }
}