using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Юзинги чистим
public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Проверку на rigidbody не надо, тк у тебя коллизии только с rigidbody и происходят. Использовать TryGetComponent
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Player>())
            {
                enemyHealth.TakeDamage(1);
            }
        }
    }
}
