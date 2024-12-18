using UnityEngine;

public class LootHeal : MonoBehaviour, IPickup
{
    [SerializeField] private int healthValue = 1;

    public void Pick(Pickuper pickup)
    {
        PlayerHealth playerHealth = pickup.transform.GetComponent<PlayerHealth>();

        if (playerHealth)
        {
            playerHealth.AddHealth(healthValue);
            Destroy(gameObject);
        }
    }
}
