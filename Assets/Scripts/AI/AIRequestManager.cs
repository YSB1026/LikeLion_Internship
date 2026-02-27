using System.Threading.Tasks;
using UnityEngine;

public class AIRequestManager
{
    private GeminiManager geminiManager;

    public AIRequestManager(GeminiManager geminiManager = null)
    {
        this.geminiManager = geminiManager ?? GameObject.FindFirstObjectByType<GeminiManager>();

        if (this.geminiManager == null)
        {
            Debug.LogError("[AIRequestManager] GeminiManager가 씬에 존재하지 않습니다.");
        }
    }


    public async Task<string> Generate(string fullPrompt, string playerInput)
    {
        if (geminiManager == null)
            return "AI 시스템이 초기화되지 않았습니다.";

        string result = null;
        bool completed = false;

        CoroutineRunner.Instance.StartCoroutine(
            geminiManager.SendMessage(
                playerInput,      // 유저 입력
                fullPrompt,       // Builder가 만든 완성 프롬프트
                (response) =>
                {
                    result = response;
                    completed = true;
                }
            )
        );

        float timeout = 10f;
        float timer = 0f;

        while (!completed && timer < timeout)
        {
            timer += Time.deltaTime;
            await Task.Yield();
        }

        if (!completed)
        {
            Debug.LogError("[AIRequestManager] Gemini 응답 타임아웃");
            return "AI 응답 시간이 초과되었습니다.";
        }

        return string.IsNullOrEmpty(result)
            ? "AI 응답이 비어 있습니다."
            : result;
    }
}