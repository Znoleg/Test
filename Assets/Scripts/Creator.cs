using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    

    [SerializeField] private GameObject _prefab;

    //[SerializeField] private Enemy _enemy;
    //[SerializeField] private GameObject _enemyPrefab;

    //[SerializeField] private Score _score;
    private Transform _playerTransform;

    [SerializeField] private int _yPosition = -3;
    private int[] _xCoords = { 5,6,7,14,15 };

    private void Start()
    {
        for (int i = 0; i < _xCoords.Length;i++)
        {
            Vector2 position = new Vector2(_xCoords[i], _yPosition);
            Instantiate(_prefab, position, Quaternion.identity);
        }
    }

    /* private void Update()
    {
        if(_score.Coins == 3)
        {
            CreateEnemy();
        }
    }
    */

    /*private void CreateEnemy()
    {
        Vector2 position = new Vector2(38, -3);
        Instantiate(_enemyPrefab, position, Quaternion.identity);
        _enemy.Init(_playerTransform);

        
    }*/
}
