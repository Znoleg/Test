using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Юзинги чистим
public class Pickuper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IPickup pickup))
        {
            pickup.Pick(this);
        }
    }
}
