using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{
    public string nodeId;
    public NodeType type;

    [Header("기본 정보")]
    public string speaker;
    public string emotion;
    public int trustDelta;
    public int dayId;

    [Header("브랜치 정보")]
    public string branchId;      // 루트 브랜치 ID
    public bool isRootBranch;    // 루트 여부

    [Header("상황 설명 (AI용)")]
    [TextArea(2,5)]
    public string situationDescription;

    [Header("대사 정보")]
    [TextArea(2,5)]
    public string text;
    public string nextNodeId;

    [Header("선택지")]
    public List<DialogueChoice> choices;

    public bool IsAINode => type == NodeType.AI;
}