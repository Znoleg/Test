using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int damageValue = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.rigidbody.GetComponent<PlayerHealth>();

        if (collision.rigidbody)
        {
            if (playerHealth)
            {
                playerHealth.TakeDamage(damageValue);
            }
        }
    }
}
