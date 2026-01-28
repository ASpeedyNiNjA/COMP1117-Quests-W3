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
    private float alpha = 1.0f;

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
            StartCoroutine(SoulFade());
        }
    }
    private IEnumerator FlashBlack()
    {
        spriteRenderer.color = Color.black;
        yield return new WaitForSeconds(0.6f);
        spriteRenderer.color = OGcolor;       
    }


    //spriteRenderer.color = new Color(1, 1, 1, 0.5f);

    private IEnumerator SoulFade()
    {
        spriteRenderer.color = new Color(1, 1, 1, alpha);
        alpha -= 0.2f;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(1, 1, 1, alpha);
        alpha -= 0.2f;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(1, 1, 1, alpha);
        alpha -= 0.2f;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(1, 1, 1, alpha);
        alpha -= 0.2f;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(1, 1, 1, alpha);
        alpha -= 0.2f;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(1, 1, 1, alpha);
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
