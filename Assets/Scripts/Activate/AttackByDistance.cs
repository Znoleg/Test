using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackByDistance : MonoBehaviour
{
    [SerializeField] private float DistanceToAttack = 8f;
    private bool isActiveToAttack = true;
    private Activator activator;

    private void Start()
    {
        activator = FindObjectOfType<Activator>();
        activator.ObjectsToAttack.Add(this);
    }
    
    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (isActiveToAttack)
        {
            if (distance > DistanceToAttack)
            {
                Deactivate();
            }
        }

        else
        {
            if (distance < DistanceToAttack)
            {
                Activate();
            }
        }


    }
    public void Activate()
    {
        isActiveToAttack = true;
        gameObject.GetComponent<Enemy>().enabled = true;
    }

    public void Deactivate()
    {
        isActiveToAttack = false;
        gameObject.GetComponent<Enemy>().enabled = false;
    }

}
