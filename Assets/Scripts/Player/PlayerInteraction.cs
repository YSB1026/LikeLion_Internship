using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerInteraction : MonoBehaviour
{
    private PlayerInputHandler input;
    private NPCController currentNPC;

    private void Start()
    {
        input = GetComponentInParent<PlayerInputHandler>();
    }

    private void Update()
    {
        if (input.InteractPressed && input.CanInteract && currentNPC != null)
        {
            currentNPC.Interact();
            input.ConsumeInteract();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
            currentNPC = other.GetComponent<NPCController>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC") && other.GetComponent<NPCController>() == currentNPC)
            currentNPC = null;
    }
}