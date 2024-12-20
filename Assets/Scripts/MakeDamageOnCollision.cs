using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Юзинги чистим, отступы контролируем
public class MakeDamageOnCollision : MonoBehaviour
{
    //Не выставляй значение, если в инспекторе уже сериализуется поле. Нет смысла, только запутывает
    [SerializeField] private int damageValue = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHaveHealth objectHealth = collision.transform.GetComponent<IHaveHealth>();

        //Проверка не нужна, тк коллизия и так происходит только с объектами, на которые риджидбоди навешен
        if (collision.rigidbody)
        { 
                objectHealth.TakeDamage(damageValue);
        }
    }
}
