using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

[RequireComponent(typeof(PlayerInputHandler), typeof(Rigidbody2D))]
public class PlayerController : Character
{

    // Side-quest variables left-over/not-included in lesson
    public Image HPFull;

    //Jumping Logic
    [Header("Movement Settings")]
    [SerializeField] private float jumpForce = 12f;         // The force of the jump
    [SerializeField] private LayerMask groundLayer;         // Checking to see if I'm standing on the ground layer
    [SerializeField] private Transform groundCheck;         // Position of the ground check
    [SerializeField] private float groundCheckRadius = 0.2f; // Size of the ground check

    // Components
    private Rigidbody2D rBody;              // Used to apply a force to move or jump
    private PlayerInputHandler input;       // Reads the input
    private bool isGrounded;                // Holds the result of the ground check operation

    protected override void Awake()
    { 
        base.Awake();
        // Initialize
        rBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        //Perform a ground check, not physics based
        isGrounded= Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.Log(isGrounded);
    }

    void FixedUpdate()
    {
        if(IsDead)
        {
            return;
        }

        // Handle movement
        HandleMovement();
        // Handle jumping
        HandleJump();
        // Optional: Handle Mario-like falling
    }

    private void HandleMovement()
    {
        // Get MoveInput from InputHandler
        // Get MoveSpeed from our Parent class (Character)
        float horizontalVelocity = input.MoveInput.x * MoveSpeed;

        rBody.linearVelocity = new Vector2(horizontalVelocity, rBody.linearVelocity.y);
    }

    private void HandleJump()
    {
        //Only jump if the input handle's jump property is true
        if (input.JumpTriggered && isGrounded)
        {
            //Apply Jump Force
            ApplyJumpForce();
            // "Consume the jump"
        }
    }

    private void ApplyJumpForce()
    {
        //Reset vertical velocity first to ensure consistent jump height.
        rBody.linearVelocity = new Vector2(rBody.linearVelocity.x, 0);

        rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

    }
    
    
    
    
    
    
    
    
    
    
    
    /*public void TakeDamage(int damageAmount)
    {
        stats.CurrentHealth -= damageAmount;
        // stats.CurrentHealth = stats.CurrentHealth - damageAmount;

        Debug.Log("Player took damage");

        //Quest 2-D Code
        HPFull.fillAmount = (float)stats.CurrentHealth / (float)stats.MaxHealth;

    }*/
}
