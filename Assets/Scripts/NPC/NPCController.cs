using UnityEngine;

public class NPCController : MonoBehaviour
{
    public string currentNodeId = "START";
    public NPCProfile npcProfile;
    TextAsset asset = null;
    public void Start()
    {
        if (npcProfile == null)
        {
            Debug.LogError("NPC Profile not found!");
            return;
        }
        asset = Resources.Load<TextAsset>($"Dialogues/{npcProfile.currentDialogueFile}");
    }
    public void Interact()
    {
        if (asset == null)
        {
            Debug.LogError("MD file not found!");
            return;
        }

        DialogueParser parser = new DialogueParser();
        var nodes = parser.Parse(asset.text);

        DialogueManager.Instance.LoadDialogue(nodes);
        DialogueManager.Instance.StartDialogue(currentNodeId);
    }
}
