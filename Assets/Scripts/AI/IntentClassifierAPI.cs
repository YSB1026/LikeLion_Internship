using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public enum IntentType
{
    IN_WORLD,      // 게임 내 정상 대화
    ACCUSATION,    // NPC 지목/의심 발언
    META,          // 게임 구조/AI/시스템 관련 메타 발언
    NOISE          // 의미 없는 잡음
}

public static class IntentTypeExtensions
{
    public static string GetDescription(this IntentType type)
    {
        return type switch
        {
            IntentType.IN_WORLD => "게임 세계관 안에서 정상적인 대화",
            IntentType.ACCUSATION => "NPC를 의심하거나 범죄와 관련해 지목하는 발언",
            IntentType.META => "시스템, AI, 게임 구조 등 메타적 발언",
            IntentType.NOISE => "의미 없는 잡음이나 무의미한 발언",
            _ => "알 수 없음"
        };
    }
}

public class IntentClassifierAPI
{
    private GeminiManager geminiManager;

    private readonly string[] accusationKeywords =
        { "범인", "네가 했", "당신이 했", "네가 죽였", "당신이 죽였" };

    private readonly string[] metaKeywords =
        { "게임", "정답", "엔딩", "시스템", "공략" };

    public IntentClassifierAPI(GeminiManager manager = null)
    {
        geminiManager = manager ?? GameObject.FindFirstObjectByType<GeminiManager>();
    }

    /// <summary>
    /// 입력 문장을 분석하여 IntentType 반환
    /// </summary>
    public async Task<IntentType> Classify(string input)
    {
        if (string.IsNullOrWhiteSpace(input) || input.Length < 2)
            return IntentType.NOISE;

        string normalized = Normalize(input);

        // 1️ 룰 기반 판별 우선
        var ruleResult = RuleBasedClassify(normalized);
        if (ruleResult.HasValue)
        {
            Debug.Log($"[IntentClassifier] Rule-based intent: {ruleResult.Value} ({ruleResult.Value.GetDescription()})");
            return ruleResult.Value;
        }

        // 2️ Gemini 기반 판별 (애매한 경우)
        if (geminiManager == null)
        {
            Debug.Log($"[IntentClassifier] Gemini unavailable, defaulting to IN_WORLD");
            return IntentType.IN_WORLD;
        }

        try
        {
            IntentType aiIntent = await GeminiClassify(normalized);
            Debug.Log($"[IntentClassifier] Gemini-detected intent: {aiIntent} ({aiIntent.GetDescription()})");
            return aiIntent;
        }
        catch (Exception ex)
        {
            Debug.LogWarning($"[IntentClassifier] Gemini failed: {ex.Message}, fallback IN_WORLD");
            return IntentType.IN_WORLD;
        }
    }

    // -----------------------------
    // 1차: 룰 기반 판별
    // -----------------------------
    private IntentType? RuleBasedClassify(string input)
    {
        if (ContainsKeyword(input, metaKeywords))
            return IntentType.META;

        if (ContainsKeyword(input, accusationKeywords))
            return IntentType.ACCUSATION;

        return null; // 애매하면 Gemini로
    }

    // -----------------------------
    // 2차: Gemini 판별 (TaskCompletionSource 사용)
    // -----------------------------
    private async Task<IntentType> GeminiClassify(string input)
    {
        string systemPrompt =
            "다음 문장을 분석하여 intent를 분류하세요.\n" +
            "가능한 값: IN_WORLD, ACCUSATION, META, NOISE\n" +
            "반드시 아래 JSON 형식으로만 답하세요.\n" +
            "IN_WORLD - 게임 세계관 안에서 정상적인 대화\n" +
            "ACCUSATION - NPC를 의심하거나 범죄와 관련해 지목하는 발언\n" +
            "META - 시스템, AI, 게임 구조 등 메타적 발언\n" +
            "NOISE - 의미 없는 잡음이나 무의미한 발언\n" +
            "{ \"intent\": \"VALUE\" }";

        string result = await SendMessageAsync(input, systemPrompt, 5f);

        if (string.IsNullOrWhiteSpace(result))
        {
            Debug.LogWarning("[IntentClassifier] Gemini returned empty, fallback IN_WORLD");
            return IntentType.IN_WORLD;
        }

        return ParseIntent(result);
    }

    private Task<string> SendMessageAsync(string input, string systemPrompt, float timeoutSeconds)
    {
        var tcs = new TaskCompletionSource<string>();

        CoroutineRunner.Instance.StartCoroutine(
            geminiManager.SendMessage(
                input,
                systemPrompt,
                (response) => tcs.TrySetResult(response)
            )
        );

        // Timeout 처리
        _ = Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(timeoutSeconds));
            if (!tcs.Task.IsCompleted)
                tcs.TrySetResult(null);
        });

        return tcs.Task;
    }

    // -----------------------------
    // JSON 파싱 안정화
    // -----------------------------
    private IntentType ParseIntent(string json)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(json))
                return IntentType.IN_WORLD;

            // 1. 마크다운/백틱/불필요 텍스트 제거
            json = json.Trim().Trim('`', '\n', '\r');

            // 2. 앞에 "json" 문자열 붙은 경우 제거
            if (json.StartsWith("json", StringComparison.OrdinalIgnoreCase))
                json = json.Substring(4).Trim();

            // 3. JSON 아닌 경우 fallback
            if (!json.StartsWith("{") || !json.Contains("intent"))
            {
                Debug.LogWarning($"[IntentClassifier] Gemini response not JSON, fallback IN_WORLD. 입력: {json}");
                return IntentType.IN_WORLD;
            }

            IntentWrapper wrapper = JsonUtility.FromJson<IntentWrapper>(json);
            if (wrapper != null && !string.IsNullOrWhiteSpace(wrapper.intent))
            {
                if (Enum.TryParse(wrapper.intent, true, out IntentType parsed))
                    return parsed;

                Debug.LogWarning($"[IntentClassifier] Enum parse failed, fallback IN_WORLD. intent: {wrapper.intent}");
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning($"[IntentClassifier] ParseIntent exception: {e.Message}, 입력: {json}");
        }

        return IntentType.IN_WORLD;
    }

    [Serializable]
    private class IntentWrapper
    {
        public string intent;
    }

    private string Normalize(string input)
    {
        return input.Trim().ToLowerInvariant();
    }

    private bool ContainsKeyword(string input, string[] keywords)
    {
        return keywords.Any(k => input.Contains(k));
    }
}