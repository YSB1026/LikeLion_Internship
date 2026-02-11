using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI dialogueText;
    public GameObject choiceContainer;
    public Button choiceButtonPrefab;
    private DialogueManager manager;

    void Start()
    {
        manager = FindFirstObjectByType<DialogueManager>();
    }

    public void ShowNode(DialogueNode node)
    {
        if (string.IsNullOrEmpty(node.nextNodeId) && (node.type != NodeType.Choice || node.choices.Count == 0))
        {
            HideDialoguePanel();
            return;
        }

        dialogueText.text = "";
        speakerText.text = node.speaker;
        ShowDialoguePanel();


        switch (node.type)
        {
            case NodeType.Fixed:
            case NodeType.AI:
                dialogueText.text = node.text;
                HideChoices();
                break;

            case NodeType.Choice:
                if (node.choices == null || node.choices.Count == 0)
                {
                    Debug.LogWarning("[UI] Choice node has no choices!");
                    HideChoices();
                    return;
                }

                ShowChoices(node.choices);
                break;
        }
    }


    public void ShowChoices(List<DialogueChoice> choices)
    {
        choiceContainer.SetActive(true);

        foreach (Transform child in choiceContainer.transform)
            Destroy(child.gameObject);

        foreach (var choice in choices)
        {
            var btn = Instantiate(choiceButtonPrefab, choiceContainer.transform);

            btn.GetComponentInChildren<TMP_Text>().text = choice.text;
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() =>
            {
                DialogueManager.Instance.SelectChoice(choice);
            });
        }
    }

    public void HideChoices()
    {
        choiceContainer.SetActive(false);

        foreach (Transform child in choiceContainer.transform)
            Destroy(child.gameObject);
    }

    private void ShowDialoguePanel()
    {
        dialoguePanel.SetActive(true);
    }
    private void HideDialoguePanel()
    {
        dialoguePanel.SetActive(false);
    }
}
