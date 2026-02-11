using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerInteraction : MonoBehaviour
{
    PlayerInputHandler input;
    NPCController currentNPC;
    void Start()
    {
        input = GetComponentInParent<PlayerInputHandler>();
    }

    void Update()
    {
        if (input.InteractPressed && currentNPC != null)
        {
            currentNPC.Interact();
            input.ConsumeInteract();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            currentNPC = other.GetComponent<NPCController>();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            if (other.GetComponent<NPCController>() == currentNPC)
            {
                currentNPC = null;
            }
        }
    }
}
