using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class AIInputHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField aiInputField;

    private DialogueManager dialogueManager;

    private void Awake()
    {
        dialogueManager = DialogueManager.Instance;

        aiInputField.onSubmit.AddListener(OnInputSubmitted);
    }

    private void OnInputSubmitted(string input)
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SubmitInput();
        }
    }

    private async void SubmitInput()
    {
        string input = aiInputField.text;
        if (string.IsNullOrWhiteSpace(input)) return;

        aiInputField.interactable = false; // 입력 잠금

        await dialogueManager.RequestAIResponse(input);

        aiInputField.interactable = true; // 입력 잠금 해제
        aiInputField.ActivateInputField();
    }
}