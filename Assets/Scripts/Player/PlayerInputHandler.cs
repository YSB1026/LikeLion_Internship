using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool InteractPressed { get; private set; }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            MoveInput = context.ReadValue<Vector2>();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
            InteractPressed = true;
    }

    public void ConsumeInteract()
    {
        InteractPressed = false;
    }
}
