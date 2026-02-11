using UnityEngine.EventSystems;
using UnityEngine;

public class DialoguePanelClick : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        DialogueManager.Instance.Advance();
    }
}
