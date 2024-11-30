using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] private int healthValue = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.attachedRigidbody.GetComponent<PlayerHealth>();

        if(playerHealth)
        {
            playerHealth.AddHealth(healthValue);
            Destroy(gameObject);
        }
    }
}
