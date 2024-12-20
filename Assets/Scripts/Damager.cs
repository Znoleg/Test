using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Юзинги чистим. Если класс ничего не делает, то он и не нужен
public class Damager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IHaveHealth havehealth))
        {
         
        }
    }
}
