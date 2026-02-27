using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool InteractPressed { get; private set; }
    public bool CanInteract { get; private set; } = true;

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && CanInteract)
            InteractPressed = true;
    }

    public void ConsumeInteract()
    {
        InteractPressed = false;
    }

    public void SetInteractEnabled(bool enabled)
    {
        CanInteract = enabled;
        if (!enabled)
            ConsumeInteract();
    }
}