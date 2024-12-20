using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Чистим юзинги. 
public class CollectControl : MonoBehaviour
{
    [SerializeField] private Score score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //gameObject не нужен, можно делать сразу collision.TryGetComponent(out Coin coin) 
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            score.AddOne();
            coin.Destroy();
        }
    }
}
