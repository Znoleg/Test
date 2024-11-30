using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectControl : MonoBehaviour
{
    [SerializeField] private Score score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin coin = collision.gameObject.GetComponent<Coin>();

        if (coin)
        {
            score.AddOne();
            coin.DestroyCoin();
        }
    }
}
