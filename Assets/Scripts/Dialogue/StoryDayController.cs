using System.Collections.Generic;
using UnityEngine;

public class StoryDayController : MonoBehaviour
{
    public static StoryDayController Instance;

    public int currentDay;
    public bool isDayCompleted = false;
    public List<NPCProfile> npcs;

    private Dictionary<int, Dictionary<NPCProfile, HashSet<string>>>
        completedBranches = new();

    private Dictionary<int, Dictionary<NPCProfile, HashSet<string>>>
        requiredBranches = new();

    private DialogueManager dialogueManager;
    private DialogueUI dialogueUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        dialogueManager = DialogueManager.Instance;
        dialogueUI = FindFirstObjectByType<DialogueUI>();

        currentDay = 1;//나중에 저장된 값 불러오기
        ChangeNpCsDialogueFile();
    }

    /* ───────────────────────── */

    public void RegisterCompletedBranch(
        NPCProfile npc,
        string branchId)
    {
        if (npc == null)
        {
            //Debug.LogWarning("RegisterCompletedBranch: npc is null");
            return;
        }

        //Debug.Log("=======================================");
        //Debug.Log($"[RegisterCompletedBranch] Day: {currentDay}");
        //Debug.Log($"NPC: {npc.npcName}");
        //Debug.Log($"추가하려는 Branch: '{branchId}'");

        InitDayIfNeeded();

        if (!completedBranches[currentDay].ContainsKey(npc))
        {
            completedBranches[currentDay][npc] =
                new HashSet<string>();
            //Debug.Log("completedBranches 새로 생성");
        }

        if (!requiredBranches[currentDay].ContainsKey(npc))
        {
            requiredBranches[currentDay][npc] =
                dialogueManager.GetRootBranchSet();

            //Debug.Log("requiredBranches 생성됨");
            //Debug.Log("=== required 목록 ===");
            //foreach (var r in requiredBranches[currentDay][npc])
            //Debug.Log($"  - '{r}'");
        }

        var completed = completedBranches[currentDay][npc];
        var required = requiredBranches[currentDay][npc];

        completed.Add(branchId);

        // Debug.Log("=== completed 목록 ===");
        // foreach (var c in completed)
        // Debug.Log($"  - '{c}'");

        // Debug.Log("=== required 목록 재확인 ===");
        // foreach (var r in required)
        // Debug.Log($"  - '{r}'");

        bool isNpcComplete = completed.IsSupersetOf(required);
        //Debug.Log($"IsSupersetOf 결과: {isNpcComplete}");

        if (isNpcComplete)
        {
            //Debug.Log($"NPC 완료 처리: {npc.npcName}");

            dialogueManager.Context
                .MarkNPCComplete(currentDay, npc.npcName);
        }

        isDayCompleted = IsDayComplete();
        //Debug.Log($"IsDayComplete 결과: {isDayCompleted}");

        if (isDayCompleted)
        {
            Debug.Log(" DAY COMPLETE ");
            dialogueUI?.ShowNextDayButton(LoadNextDay);
        }

        //Debug.Log("=======================================");
    }

    private void InitDayIfNeeded()
    {
        if (!completedBranches.ContainsKey(currentDay))
        {
            completedBranches[currentDay] =
                new Dictionary<NPCProfile, HashSet<string>>();

            //Debug.Log("completedBranches[currentDay] 생성");
        }

        if (!requiredBranches.ContainsKey(currentDay))
        {
            requiredBranches[currentDay] =
                new Dictionary<NPCProfile, HashSet<string>>();

            //Debug.Log("requiredBranches[currentDay] 생성");
        }
    }

    private bool IsDayComplete()
    {
        //Debug.Log("---- IsDayComplete 검사 시작 ----");

        foreach (var npc in npcs)
        {
            bool npcComplete =
                dialogueManager.Context
                .IsNPCComplete(currentDay, npc.npcName);

            //Debug.Log($"NPC '{npc.npcName}' 완료 여부: {npcComplete}");

            if (!npcComplete)
            {
                //Debug.Log("DayComplete = false");
                return false;
            }
        }

        //Debug.Log("DayComplete = true");
        return true;
    }

    private void LoadNextDay()
    {
        currentDay++;
        isDayCompleted = false;

        // 다음 날 초기화
        if (!completedBranches.ContainsKey(currentDay))
            completedBranches[currentDay] = new Dictionary<NPCProfile, HashSet<string>>();

        if (!requiredBranches.ContainsKey(currentDay))
            requiredBranches[currentDay] = new Dictionary<NPCProfile, HashSet<string>>();

        ChangeNpCsDialogueFile();

        // 새로운 날 안내 UI
        dialogueUI?.ShowDayIntro(currentDay);
    }

    private void ChangeNpCsDialogueFile()
    {
        foreach (var npc in npcs)
        {
            npc.currentDialogueFile = $"Day{currentDay}_{npc.npcName}";
        }
    }
}