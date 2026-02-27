using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class GeminiManager : MonoBehaviour
{
    // 리스트에서 확인한 쿼터가 많은 모델 ID입니다.
    private const string MODEL_NAME = "gemma-3-27b-it";

    private string GetApiUrl()
    {
        string apiKey = APIKeyManager.Instance.GetAPIKey();
        if (string.IsNullOrEmpty(apiKey)) return null;

        apiKey = apiKey.Trim();
        // v1beta 경로와 모델 식별자를 조합합니다.
        return $"https://generativelanguage.googleapis.com/v1beta/models/{MODEL_NAME}:generateContent?key={apiKey}";
    }

    public IEnumerator SendMessage(
        string userMessage,
        string systemInstruction,
        Action<string> onComplete)
    {
        string apiUrl = GetApiUrl();
        if (string.IsNullOrEmpty(apiUrl))
        {
            onComplete?.Invoke("API 키 설정 오류");
            yield break;
        }

        // 💡 Gemma 호환성 핵심: system_instruction 대신 contents에 지침을 합칩니다.
        // 첫 번째 메시지에 NPC 설정과 유저의 질문을 함께 전달하여 가이드라인을 지키게 합니다.
        var requestData = new GeminiRequest
        {
            contents = new Content[]
            {
                new Content
                {
                    role = "user",
                    parts = new Part[] 
                    { 
                        new Part { text = $"[System Instruction]\n{systemInstruction}\n\n[User Message]\n{userMessage}" } 
                    }
                }
            }
        };

        string jsonBody = JsonUtility.ToJson(requestData);

        using (UnityWebRequest request = new UnityWebRequest(apiUrl, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                try
                {
                    GeminiResponse response = JsonUtility.FromJson<GeminiResponse>(request.downloadHandler.text);

                    if (response?.candidates != null && response.candidates.Length > 0 &&
                        response.candidates[0].content?.parts != null && response.candidates[0].content.parts.Length > 0)
                    {
                        string assistantMessage = response.candidates[0].content.parts[0].text;
                        onComplete?.Invoke(assistantMessage);
                    }
                    else
                    {
                        onComplete?.Invoke("AI 응답 데이터가 비어 있습니다.");
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError($"[JSON Parsing Error] {e.Message}");
                    onComplete?.Invoke("데이터 파싱 실패");
                }
            }
            else
            {
                // 400 에러 발생 시 로그를 통해 구체적인 원인을 확인합니다.
                Debug.LogError($"[Gemma Error] Code: {request.responseCode}\nError: {request.error}\nBody: {request.downloadHandler.text}");
                onComplete?.Invoke("연결 실패");
            }
        }
    }
}

// ──────────────────────────────
// Gemma/Gemini 통합 데이터 구조
// ──────────────────────────────
[Serializable]
public class GeminiRequest
{
    // Gemma 모델과의 호환성을 위해 system_instruction 필드를 제거했습니다.
    public Content[] contents;
}

[Serializable]
public class Content
{
    public string role; 
    public Part[] parts;
}

[Serializable]
public class Part
{
    public string text;
}

[Serializable]
public class GeminiResponse
{
    public Candidate[] candidates;
}

[Serializable]
public class Candidate
{
    public Content content;
}