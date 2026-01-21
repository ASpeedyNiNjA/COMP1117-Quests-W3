using UnityEngine;

public class Character : MonoBehaviour
{
    // Private Variables
    [Header("Character Stats")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private int maxHealth = 100;

    private int currentHealth;

    private bool isDead = false;

    // Public Properties
    public float MoveSpeed
    {
        // Read-only
        get { return moveSpeed; }
    }

    public bool IsDead
    {
        get { return isDead; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        Debug.Log($"{gameObject.name} Hp is now: {CurrentHealth}");

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        Debug.Log($"{gameObject.name} has died.");
    }


}
