using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public NPCProfile currentNPCProfile;

    private DialogueUI dialogueUI;
    private PlayerInputHandler playerInput;

    private Dictionary<string, DialogueNode> nodes;
    private DialogueNode currentNodeInternal;

    public DialogueNode CurrentNode => currentNodeInternal;
    public DialogueContext Context { get; private set; } = new DialogueContext();

    private string startNodeId = "START";
    private string currentRootBranchId;

    /* ────────────────────────────── */
    /* Unity Lifecycle */
    /* ────────────────────────────── */

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        dialogueUI = FindFirstObjectByType<DialogueUI>();
        playerInput = FindFirstObjectByType<PlayerInputHandler>();
    }

    /* ────────────────────────────── */
    /* Dialogue Load */
    /* ────────────────────────────── */

    public void LoadDialogue(Dictionary<string, DialogueNode> parsedNodes)
    {
        nodes = parsedNodes;
    }

    public void StartDialogue(string startId)
    {
        if (nodes == null || !nodes.ContainsKey(startId))
        {
            Debug.LogError($"Start node not found: {startId}");
            return;
        }

        startNodeId = startId;
        currentRootBranchId = null;

        playerInput?.SetInteractEnabled(false);
        EnterNode(nodes[startId]);
    }

    /* ────────────────────────────── */
    /* Node Flow */
    /* ────────────────────────────── */

    private void EnterNode(DialogueNode node)
    {
        if (node == null)
        {
            Debug.LogError("EnterNode: node is null");
            return;
        }

        currentNodeInternal = node;

        ApplyNodeEffect(node);

        dialogueUI?.ShowNode(node);
        dialogueUI?.SetAIInputActive(node.type == NodeType.AI);

        if (IsEndNode(node))
        {
            HandleBranchComplete();
        }
    }

    private bool IsEndNode(DialogueNode node)
    {
        return node.type == NodeType.End
            || (string.IsNullOrEmpty(node.nextNodeId)
                && (node.choices == null || node.choices.Count == 0));
    }

    private void GoToNode(string nodeId)
    {
        if (string.IsNullOrEmpty(nodeId))
        {
            Debug.LogWarning("GoToNode: nodeId is null or empty");
            return;
        }

        if (!nodes.ContainsKey(nodeId))
        {
            Debug.LogError($"Node not found: {nodeId}");
            return;
        }

        EnterNode(nodes[nodeId]);
    }

    public void SelectChoice(DialogueChoice choice)
    {
        if (choice == null)
        {
            Debug.LogWarning("SelectChoice: choice is null");
            return;
        }

        // START에서 선택된 nextNodeId가 루트 브랜치
        if (currentNodeInternal != null &&
            currentNodeInternal.nodeId == startNodeId)
        {
            currentRootBranchId = choice.nextNodeId;
            Debug.Log($"루트 브랜치 선택됨: {currentRootBranchId}");
        }

        GoToNode(choice.nextNodeId);
    }

    public void Advance()
    {
        if (currentNodeInternal == null){
            EndDialogue();
            return;
        }

        if (!string.IsNullOrEmpty(currentNodeInternal.nextNodeId))
        {
            GoToNode(currentNodeInternal.nextNodeId);
        }
        else
        {
            HandleBranchComplete();
        }
    }

    private void ApplyNodeEffect(DialogueNode node)
    {
        if (node.trustDelta != 0)
        {
            Context.AddTrust(node.trustDelta);
            Debug.Log($"Trust 변화: {node.trustDelta}");
        }
    }

    /* ────────────────────────────── */
    /* Branch Completion */
    /* ────────────────────────────── */

    private void HandleBranchComplete()
    {
        // Debug.Log("HandleBranchComplete 호출");
        // Debug.Log($"현재 Root Branch ID: {currentRootBranchId}, NPC: {(currentNPCProfile != null ? currentNPCProfile.npcName : "null")}");
        if (!string.IsNullOrEmpty(currentRootBranchId) &&
            currentNPCProfile != null)
        {
            
            StoryDayController.Instance?
                .RegisterCompletedBranch(
                    currentNPCProfile,
                    currentRootBranchId
                );
        }
        else
        {
            Debug.LogWarning("BranchComplete 조건 불충족 (rootBranchId 또는 NPC null)");
        }

        currentRootBranchId = null;
        EndDialogue();
    }

    private void EndDialogue()
    {
        currentNodeInternal = null;

        dialogueUI?.ResetAllUI(StoryDayController.Instance.isDayCompleted);
        playerInput?.SetInteractEnabled(true);
    }

    /* ────────────────────────────── */
    /* Root Branch Set */
    /* ────────────────────────────── */

    public HashSet<string> GetRootBranchSet()
    {
        HashSet<string> result = new HashSet<string>();

        if (!nodes.ContainsKey(startNodeId))
            return result;

        var startNode = nodes[startNodeId];

        if (startNode.choices == null)
            return result;

        foreach (var choice in startNode.choices)
        {
            result.Add(choice.nextNodeId);
        }

        return result;
    }

    /* ────────────────────────────── */
    /* AI 처리 */
    /* ────────────────────────────── */

    public async Task RequestAIResponse(string playerText)
    {
        if (currentNodeInternal == null ||
            currentNodeInternal.type != NodeType.AI)
            return;

        if (currentNPCProfile == null)
        {
            Debug.LogError("NPCProfile이 설정되지 않았습니다.");
            return;
        }

        string aiResponse = await AIResponsePipeline.Instance.Process(
            currentNPCProfile,
            currentNodeInternal,
            Context,
            playerText
        );

        dialogueUI?.DisplayAIResponse(playerText, aiResponse);
    }
}