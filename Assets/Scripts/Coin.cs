using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Юзинги чистим. Лучше переназвать класс в условный CoinsDestroyer, если ты хочешь именно тут спрятать логику уничтожения монетки
public class Coin : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
