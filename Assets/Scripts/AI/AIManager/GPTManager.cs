using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

// ──────────────────────────────
// OpenAI 연동 매니저
// ──────────────────────────────
public class GPTManager : MonoBehaviour
{
    private const string API_URL = "https://api.openai.com/v1/chat/completions";

    public IEnumerator SendMessage(
        string userMessage,
        string npcPrompt,
        Action<string> onComplete)
    {
        APIKeyManager keyData = Resources.Load<APIKeyManager>("APIKeyData");
        string apiKey = keyData.GetAPIKey();
        
        if (string.IsNullOrEmpty(apiKey))
        {
            onComplete?.Invoke("API 키가 설정되지 않았습니다.");
            yield break;
        }

        // 요청 데이터
        var requestData = new ChatRequest
        {
            model = "gpt-3.5-turbo",
            messages = new Message[]
            {
                new Message { role = "system", content = npcPrompt },
                new Message { role = "user", content = userMessage }
            },
            max_tokens = 200
        };

        string jsonBody = JsonUtility.ToJson(requestData);

        using (UnityWebRequest request = new UnityWebRequest(API_URL, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {apiKey}");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var response = JsonUtility.FromJson<ChatResponse>(request.downloadHandler.text);
                string assistantMessage = response.choices[0].message.content;
                onComplete?.Invoke(assistantMessage);
            }
            else
            {
                Debug.LogError($"API Error: {request.error}");
                onComplete?.Invoke("죄송합니다, 응답을 받지 못했습니다.");
            }
        }
    }
}

// ──────────────────────────────
// 요청/응답 구조
// ──────────────────────────────
[Serializable]
public class ChatRequest
{
    public string model;
    public Message[] messages;
    public int max_tokens;
}

[Serializable]
public class Message
{
    public string role;
    public string content;
}

[Serializable]
public class ChatResponse
{
    public Choice[] choices;
}

[Serializable]
public class Choice
{
    public Message message;
}