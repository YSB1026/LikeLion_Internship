using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueParser
{
    public Dictionary<string, DialogueNode> Parse(string rawMarkdown)
    {
        var nodes = new Dictionary<string, DialogueNode>();
        
        var blocks = rawMarkdown.Split("## NODE:");
        foreach (var block in blocks.Skip(1))
        {
            var lines = block.Trim().Split('\n').Select(l => l.Trim()).ToList();
            if (lines.Count == 0) continue;

            string nodeId = lines[0];

            var meta = new Dictionary<string, string>();
            int index = 1;

            for (; index < lines.Count; index++)
            {
                if (string.IsNullOrWhiteSpace(lines[index]))
                {
                    index++; // skip empty line
                    break;
                }

                var split = lines[index].Split(':', 2);
                if (split.Length == 2)
                    meta[split[0].Trim()] = split[1].Trim();
            }

            // 3. Node type
            NodeType type = ParseNodeType(meta.GetValueOrDefault("type"));

            var node = new DialogueNode
            {
                nodeId = nodeId,
                type = type,
                speaker = meta.GetValueOrDefault("speaker"),
                emotion = meta.GetValueOrDefault("emotion"),
                trustDelta = ParseInt(meta, "trust_delta"),
                nextNodeId = meta.GetValueOrDefault("next"),
                choices = new List<DialogueChoice>()
            };

            // 4. Body
            var bodyLines = lines.Skip(index).ToList();

            if (type == NodeType.Choice)
            {
                foreach (var line in bodyLines)
                {
                    if (!line.StartsWith("-")) continue;

                    // - [텍스트] -> NODE_ID
                    int textStart = line.IndexOf('[');
                    int textEnd = line.IndexOf(']');
                    int arrowIndex = line.IndexOf("->");

                    if (textStart == -1 || textEnd == -1 || arrowIndex == -1)
                        continue;

                    string choiceText = line.Substring(textStart + 1, textEnd - textStart - 1).Trim();
                    string nextId = line.Substring(arrowIndex + 2).Trim();

                    node.choices.Add(new DialogueChoice
                    {
                        text = choiceText,
                        nextNodeId = nextId
                    });
                }
            }
            else
            {
                node.text = string.Join("\n", bodyLines);
            }

            if (!nodes.ContainsKey(nodeId))
                nodes.Add(nodeId, node);
            else
                Debug.LogError($"Duplicate nodeId detected: {nodeId}");
        }

        return nodes;
    }

    private NodeType ParseNodeType(string type)
    {
        return type switch
        {
            "FIXED" => NodeType.Fixed,
            "CHOICE" => NodeType.Choice,
            "AI" => NodeType.AI,
            _ => NodeType.Fixed
        };
    }

    private int ParseInt(Dictionary<string, string> meta, string key)
    {
        if (meta.TryGetValue(key, out var value) && int.TryParse(value, out var result))
            return result;
        return 0;
    }
}
