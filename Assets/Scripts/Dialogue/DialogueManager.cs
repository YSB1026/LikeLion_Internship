using System.Collections.Generic;
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public DialogueUI dialogueUI;
    private Dictionary<string, DialogueNode> nodes;
    private DialogueNode currentNode;
    public DialogueContext Context { get; private set; }

    private void Awake()
    {
        Instance = this;
        Context = new DialogueContext();
    }

    public void LoadDialogue(Dictionary<string, DialogueNode> parsedNodes)
    {
        nodes = parsedNodes;
    }

    public void StartDialogue(string startNodeId)
    {
        if (!nodes.ContainsKey(startNodeId))
        {
            Debug.LogError($"Start node not found: {startNodeId}");
            return;
        }

        currentNode = nodes[startNodeId];
        EnterNode(nodes[startNodeId]);
    }

    public void Advance()
    {
        if (string.IsNullOrEmpty(currentNode.nextNodeId))
        {
            EndDialogue();
            return;
        }

        GoToNode(currentNode.nextNodeId);
    }

    private void EndDialogue()
    {
        Debug.Log("Dialogue Ended");
    }

    void ApplyNodeEffect(DialogueNode node)
    {
        if (node.trustDelta != 0)
        {
            Context.AddTrust(node.trustDelta);
        }

        // 추후 flag 추가
    }

    #region UI 연동

    public void SelectChoice(DialogueChoice choice)
    {
        GoToNode(choice.nextNodeId);
    }
    void GoToNode(string nodeId)
    {
        if (!nodes.ContainsKey(nodeId))
        {
            Debug.LogError($"Node not found: {nodeId}");
            return;
        }

        currentNode = nodes[nodeId];
        EnterNode(currentNode);
    }
    void EnterNode(DialogueNode node)
    {
        ApplyNodeEffect(node);
        dialogueUI.ShowNode(node);
    }
    #endregion
}

