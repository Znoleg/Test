using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectControl : MonoBehaviour
{
    [SerializeField] private Score score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            score.AddOne();
            coin.Destroy();
        }
    }
}
