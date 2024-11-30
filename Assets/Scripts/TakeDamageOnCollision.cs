using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Player>())
            {
                enemyHealth.TakeDamage(1);
            }
        }
    }
}
