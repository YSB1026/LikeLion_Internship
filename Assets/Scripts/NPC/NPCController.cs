using UnityEngine;

public class NPCController : MonoBehaviour
{
    private string currentNodeId = "START";
    private TextAsset dialogueFile;
    public NPCProfile npcProfile;
    private void Start()
    {
        if (npcProfile == null)
        {
            Debug.LogError("NPC Profile not found!");
            return;
        }

        // 초기 MD 로드
        LoadDialogueAsset();
    }

    public void Interact()
    {
        if (!LoadDialogueAsset())
        {
            Debug.LogError($"MD file not found for {npcProfile.npcName}: {npcProfile.currentDialogueFile}");
            return;
        }

        DialogueParser parser = new DialogueParser();
        var nodes = parser.Parse(dialogueFile.text);

        DialogueManager.Instance.currentNPCProfile = npcProfile;
        DialogueManager.Instance.LoadDialogue(nodes);
        DialogueManager.Instance.StartDialogue(currentNodeId);
    }

    private bool LoadDialogueAsset()
    {
        string fileName = npcProfile.currentDialogueFile.Trim();
        dialogueFile = Resources.Load<TextAsset>($"Dialogues/{fileName}");
        return dialogueFile != null;
    }
}