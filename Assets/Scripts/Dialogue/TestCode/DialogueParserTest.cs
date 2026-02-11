using UnityEngine;

public class DialogueParserTest : MonoBehaviour
{
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

        Debug.Log($"Parsed Node Count: {nodes.Count}");

        foreach (var node in nodes.Values)
        {
            Debug.Log($"NodeID: {node.nodeId}");
            Debug.Log($"Type: {node.type}");
            Debug.Log($"Speaker: {node.speaker}");
            Debug.Log($"Next: {node.nextNodeId}");
            Debug.Log($"Text: {node.text}");
            Debug.Log("----");
        }
    }
}
