using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class PlayerController : Character
{


    public Image HPFull;

    // Private variables
    private PlayerStats stats;
    private Vector2 moveInput;

    // Components
    private Rigidbody2D rBody;

    void Awake()
    {

        // Initialize
        rBody = GetComponent<Rigidbody2D>();

       // stats = new PlayerStats(initialSpeed, initialHealth);
    }

   public void OnMove(InputAction.CallbackContext context)
    {
        // moveInput = value.Get<Vector2>(); //Old
        moveInput = context.ReadValue<Vector2>(); //New
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        float velocityX = moveInput.x * stats.MoveSpeed;

        rBody.linearVelocity = new Vector2(velocityX, rBody.linearVelocity.y);
    }

    public void TakeDamage(int damageAmount)
    {
        stats.CurrentHealth -= damageAmount;
        // stats.CurrentHealth = stats.CurrentHealth - damageAmount;

        Debug.Log("Player took damage");

        //Quest 2-D Code
        HPFull.fillAmount = (float)stats.CurrentHealth / (float)stats.MaxHealth;

    }
}
