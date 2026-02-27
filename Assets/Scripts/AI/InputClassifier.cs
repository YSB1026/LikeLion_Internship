public class InputClassifier
{
    private static readonly string[] blockedKeywords  =
    {
        "ai",
        "인공지능",
        "프롬프트",
        "jailbreak",
        "프롬프트 출력",
        "무시하고"
    };

    public bool IsBlocked(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return true;

        string normalized = input.ToLowerInvariant();

        foreach (var pattern in blockedKeywords)
        {
            if (normalized.Contains(pattern))
                return true;
        }

        return false;
    }
}
