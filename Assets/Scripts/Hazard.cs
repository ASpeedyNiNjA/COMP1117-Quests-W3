using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int damageToDeal = 15;
 
    private void OnTriggerEnter2D(Collider2D lava) 
    {
        if (lava.gameObject.name == "Player")
        {
            lava.GetComponent<PlayerController>().TakeDamage(damageToDeal);
        }
    }


}
