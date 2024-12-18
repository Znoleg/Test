using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int damageValue = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHaveHealth objectHealth = collision.transform.GetComponent<IHaveHealth>();

        if (collision.rigidbody)
        { 
                objectHealth.TakeDamage(damageValue);
        }
    }
}
