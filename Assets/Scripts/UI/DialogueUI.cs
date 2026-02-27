using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [Header("UI 연결")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI dialogueText;
    public Image npcImage;

    public GameObject choiceContainer;
    public Button choiceButtonPrefab;

    public TMP_InputField aiInputField;
    public Button nextDayButton;

    [Header("UI 설정")]
    public Color playerTextColor = Color.green;
    public Color aiTextColor = Color.yellow;

    private DialogueManager manager;
    private bool isChoiceLocked = false;

    private void Start()
    {
        manager = DialogueManager.Instance;
        ResetAllUI();
        ShowDayIntro(StoryDayController.Instance.currentDay);
    }

    #region Node Rendering
    public void ShowNode(DialogueNode node)
    {
        if (node == null) return;

        dialoguePanel.SetActive(true);
        speakerText.text = node.speaker;
        dialogueText.text = node.text ?? "";
        isChoiceLocked = false;
        npcImage.gameObject.SetActive(true);

        // NPC 일러스트 적용 (emotion 기반)
        var npc = manager.currentNPCProfile;
        if (npc != null)
            npcImage.sprite = npc.GetSpriteForEmotion(node.emotion);
        else
            npcImage.sprite = null;

        HideChoices();
        SetAIInputActive(node.type == NodeType.AI);

        if (node.choices != null && node.choices.Count > 0)
            ShowChoices(node.choices);
    }
    #endregion

    #region AI Handling

    public void DisplayAIResponse(string playerInput, string aiResponse)
    {
        SetAIInputActive(false);
        AppendPlayerInput(playerInput);
        AppendAIResponse(aiResponse);
    }

    private void AppendPlayerInput(string input)
    {
        string colorHex = ColorUtility.ToHtmlStringRGB(playerTextColor);
        dialogueText.text += $"\n<color=#{colorHex}>플레이어: {input}</color>";
    }

    private void AppendAIResponse(string response)
    {
        string colorHex = ColorUtility.ToHtmlStringRGB(aiTextColor);
        dialogueText.text += $"\n<color=#{colorHex}>{response}</color>";
    }
    #endregion

    #region Choice Handling
    private void ShowChoices(List<DialogueChoice> choices)
    {
        if (choices == null || choices.Count == 0) { HideChoices(); return; }

        choiceContainer.SetActive(true);
        foreach (Transform child in choiceContainer.transform) Destroy(child.gameObject);

        foreach (var choice in choices)
        {
            var btn = Instantiate(choiceButtonPrefab, choiceContainer.transform);
            btn.GetComponentInChildren<TMP_Text>().text = choice.text;

            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() =>
            {
                if (isChoiceLocked) return;
                isChoiceLocked = true;
                manager.SelectChoice(choice);
            });

            btn.gameObject.SetActive(true);
        }
    }

    private void HideChoices()
    {
        foreach (Transform child in choiceContainer.transform)
            Destroy(child.gameObject);
        choiceContainer.SetActive(false);
    }
    #endregion

    #region Day Handling
    public void ShowNextDayButton(System.Action onClick)
    {
        nextDayButton.gameObject.SetActive(true);
        nextDayButton.onClick.RemoveAllListeners();
        nextDayButton.onClick.AddListener(() =>
        {
            nextDayButton.gameObject.SetActive(false);
            onClick?.Invoke();
        });
    }


    public void ShowDayIntro(int day)
    {
        dialoguePanel.SetActive(true);
        speakerText.text = $"Day {day}";
        dialogueText.text = $"오늘은 {day}일차입니다.\n각 NPC와 대화를 진행하세요.";
        HideChoices();
        SetAIInputActive(false);
        npcImage.sprite = null;
    }
    #endregion

    #region Utility
    public void SetAIInputActive(bool active)
    {
        aiInputField.gameObject.SetActive(active);
        if (active) { dialogueText.text = ""; aiInputField.ActivateInputField(); }
        else aiInputField.text = "";
    }

    public void ResetAllUI(bool keepNextDayButton = false)
    {
        dialoguePanel.SetActive(false);
        HideChoices();
        SetAIInputActive(false);
        speakerText.text = "";
        dialogueText.text = "";
        npcImage.gameObject.SetActive(false);
        npcImage.sprite = null;

        if (!keepNextDayButton)
            nextDayButton.gameObject.SetActive(false);
    }
    #endregion
}