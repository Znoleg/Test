using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    //private int coinsCount = 40;

    private void Start()
    {
        for (int i = 5; i < 8; i++)
        {
            Vector2 position = new Vector2(i, -3);
            Instantiate(coinPrefab, position, Quaternion.identity);
        }
    }
}
