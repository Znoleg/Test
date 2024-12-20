using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Юзинги чистим.
public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    //private void Update() =>
    //transform.position = _target.position;
    //Если одна строчка в фигурных скобках, можно так написать покрасивше
    private void Update()
    {
        transform.position = _target.position;
    }
}
