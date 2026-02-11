using UnityEngine;

public class DialogueTester : MonoBehaviour
{
    public string startNodeId = "START";

    void Start()
    {
        TextAsset asset = Resources.Load<TextAsset>("Dialogues/SeoYeonTest");

        if (asset == null)
        {
            Debug.LogError("MD file not found!");
            return;
        }

        DialogueParser parser = new DialogueParser();
        var nodes = parser.Parse(asset.text);

        DialogueManager.Instance.LoadDialogue(nodes);
        DialogueManager.Instance.StartDialogue(startNodeId);
    }
}
