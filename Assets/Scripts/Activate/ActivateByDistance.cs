using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] private float DistanceToActivate = 18f;
    private bool isActive = true;
    private Activator activator;

    private void Start()
    {
        activator = FindObjectOfType<Activator>();
        activator.ObjectsToActivate.Add(this);
    }
    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (isActive)
        {
            if (distance > DistanceToActivate + 2f)
            {
                Deactivate();
            } 
        }

        else
        {
            if (distance < DistanceToActivate)
            {
                Activate();
            }
        }
        

    }
    public void Activate()
    {
        isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        activator.ObjectsToActivate.Remove(this);
    }
}
