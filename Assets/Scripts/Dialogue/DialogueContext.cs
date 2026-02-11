using System.Collections.Generic;

public class DialogueContext
{
    // 신뢰도
    public int trust = 0;

    // 사건,대화 플래그
    private Dictionary<string, bool> flags = new Dictionary<string, bool>();
    public void AddTrust(int value)
    {
        trust += value;
    }

    #region 플래그 관련 코드
    public bool HasFlag(string key)
    {
        return flags.ContainsKey(key) && flags[key];
    }

    public void SetFlag(string key, bool value = true)
    {
        flags[key] = value;
    }

    public void ClearFlag(string key)
    {
        if (flags.ContainsKey(key))
            flags.Remove(key);
    }
    #endregion
}
