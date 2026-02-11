using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{
    public string nodeId; // 노드 ID
    public NodeType type; // 노드 타입 (Fixed, AI, Choice)

    // 공통
    public string speaker; // 화자 이름
    public string emotion; //감정 상태
    public int trustDelta; //신뢰도 변화량

    // Fixed / AI
    public string text; // 대사 텍스트
    public string nextNodeId; //다음 노드 ID

    // Choice
    public List<DialogueChoice> choices; // 선택지 목록
}