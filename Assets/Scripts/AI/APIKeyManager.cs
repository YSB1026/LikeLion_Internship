using UnityEngine;

public class APIKeyManager : MonoBehaviour
{
    public static APIKeyManager Instance;

    [SerializeField]
    private string geminiApiKey;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public string GetAPIKey()
    {
        return geminiApiKey;
    }
}