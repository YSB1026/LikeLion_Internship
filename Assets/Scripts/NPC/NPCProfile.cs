using UnityEngine;

[CreateAssetMenu(fileName = "NPCProfile", menuName = "NPC/New NPC Profile")]
public class NPCProfile : ScriptableObject
{
    public string npcName;
    [Header("Resources폴더의 .md 파일 이름 ex) SeoYeonTest")]
    public string currentDialogueFile; // ex) SeoYeon.md
}