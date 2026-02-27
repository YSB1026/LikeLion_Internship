using System.Collections.Generic;
using System.Text;

public class DialogueContext
{
    public int trust = 0;

    private Dictionary<string, bool> flags = new();
    private List<string> history = new();

    // Day별 NPC 완료 관리
    private Dictionary<int, HashSet<string>> dayCompletedNPCs = new();

    /* ───────── Trust ───────── */

    public void AddTrust(int value) => trust += value;

    /* ───────── Flags ───────── */

    public bool HasFlag(string key)
        => flags.TryGetValue(key, out bool value) && value;

    public void SetFlag(string key, bool value = true)
        => flags[key] = value;

    public void ClearFlag(string key)
        => flags.Remove(key);

    /* ───────── History ───────── */

    public void AddHistory(string player, string npc)
    {
        history.Add($"Player: {player}");
        history.Add($"NPC: {npc}");

        // 최근 20줄만 유지, 성능 최적화
        if (history.Count > 20)
            history.RemoveRange(0, history.Count - 20);
    }

    public bool HasHistory() => history.Count > 0;

    public string GetHistorySummary()
    {
        StringBuilder sb = new();
        foreach (var line in history)
            sb.AppendLine(line);
        return sb.ToString();
    }

    public void ClearHistory() => history.Clear();

    /* ───────── Day Completion ───────── */

    public void MarkNPCComplete(int dayId, string npcName)
    {
        if (!dayCompletedNPCs.ContainsKey(dayId))
            dayCompletedNPCs[dayId] = new HashSet<string>();

        dayCompletedNPCs[dayId].Add(npcName);
    }

    public bool IsNPCComplete(int dayId, string npcName)
    {
        return dayCompletedNPCs.ContainsKey(dayId) &&
               dayCompletedNPCs[dayId].Contains(npcName);
    }

    public bool IsDayComplete(int dayId, List<string> allNPCs)
    {
        if (!dayCompletedNPCs.ContainsKey(dayId))
            return false;

        foreach (var npc in allNPCs)
        {
            if (!dayCompletedNPCs[dayId].Contains(npc))
                return false;
        }

        return true;
    }

    public void ResetDay(int dayId)
    {
        if (dayCompletedNPCs.ContainsKey(dayId))
            dayCompletedNPCs[dayId].Clear();
    }
}