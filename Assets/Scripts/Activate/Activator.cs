using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> ObjectsToActivate = new List<ActivateByDistance>();
    public List<AttackByDistance> ObjectsToAttack = new List<AttackByDistance>();
    public Transform PlayerTransform;

    private void Update()
    {
        for (int i = 0; i < ObjectsToActivate.Count; i++)
        {
            ObjectsToActivate[i].CheckDistance(PlayerTransform.position);
            
        }

        for (int i = 0; i < ObjectsToAttack.Count; i++)
        {
            ObjectsToAttack[i].CheckDistance(PlayerTransform.position);

        }
    }

}
