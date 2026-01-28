using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    [Header("Enemy Settings")]
    [SerializeField] private float patrolDistance = 5.0f;

    public int maxHealth = 3;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    private Color OGcolor;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Awake in Enemy.cs");
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        currentHealth = maxHealth;
        OGcolor = spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(FlashBlack());
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private IEnumerator FlashBlack()
    {

        spriteRenderer.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = OGcolor;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
