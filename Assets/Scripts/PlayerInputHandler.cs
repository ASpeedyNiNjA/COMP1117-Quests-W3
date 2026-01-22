using UnityEngine;
using UnityEngine.InputSystem;

// Read input from the Input System
public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 moveInput; // Left and right movement
    private bool jumpTriggered = false; // Jumping?

    //Public properties to read input values
    public Vector2 MoveInput
    {
        // Read-only
        get { return moveInput; }
    }

    public bool JumpTriggered
    {
        // Read-only
        get { return jumpTriggered; }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // moveInput = value.Get<Vector2>(); //Old
        
        //Save input to the field
        moveInput = context.ReadValue<Vector2>(); //New
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started) // I started to push the button
        {
            jumpTriggered = true;
        }
        else if (context.canceled) // I have let go of the button
        {
            jumpTriggered = false;
        }
    }


}
