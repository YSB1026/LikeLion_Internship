using UnityEngine;

[CreateAssetMenu(fileName = "APIKeyData", menuName = "AI_APIKEY/APIKeySO")]
public class APIKeyManager : ScriptableObject
{
    // 2. 인스펙터에서 값을 입력받습니다.
    [SerializeField]
    private string geminiApiKey;

    public string GetAPIKey()
    {
        return geminiApiKey;
    }
}