using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NPCProfile", menuName = "NPC/NPC Profile")]
public class NPCProfile : ScriptableObject
{
    [Header("기본 정보")]
    public string npcName;
    public string currentDialogueFile;

    [Header("성격 & 말투")]
    [TextArea(3,6)] public string personality;
    [TextArea(2,5)] public string[] speechExamples;

    [Header("세계관 역할")]
    [TextArea(3,6)] public string roleDescription;
    [TextArea(3,6)] public string hiddenTruth;

    [Header("지식 & 관계 설정")]
    [TextArea(2,4)] public string knowledgeLevel;
    public RelationshipType initialRelationship;
    public EmotionType baseEmotion;

    [Header("Trust 반응 단계")]
    public TrustReaction[] trustReactions;

    [Header("AI 안전 장치")]
    public string[] prohibitedWords;
    public string[] restrictedActions;
    public string[] constraints;

    [Header("감정 트리거 (선택 확장)")]
    public string[] angerTriggers;
    public string[] fearTriggers;

    [Header("NPC 이미지")]
    public Sprite defaultSprite;

    // 감정(emotion) 또는 상황 키에 따라 Sprite 지정
    public List<EmotionSpritePair> emotionSprites = new List<EmotionSpritePair>();

    public Sprite GetSpriteForEmotion(string emotion)
    {
        foreach (var pair in emotionSprites)
        {
            if (pair.key == emotion)
                return pair.sprite;
        }
        return defaultSprite;
    }
}

[System.Serializable]
public class EmotionSpritePair
{
    public string key; // ex: "neutral", "angry", "anxious"
    public Sprite sprite;
}

[System.Serializable]
public class TrustReaction
{
    public int minTrust;
    [TextArea(2,4)] public string reactionDescription;
}

public enum RelationshipType { Stranger, Acquaintance, Friend, Rival, Hostile }
public enum EmotionType { Calm, Nervous, Defensive, Cold, Angry, Sad }