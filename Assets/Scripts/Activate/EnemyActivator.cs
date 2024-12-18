using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    // public List<ActivateByDistance> ObjectsToActivate = new List<ActivateByDistance>();

    private List<ActivateByDistance> _objectsToActivateByDistance = new List<ActivateByDistance>();
    private List<AttackByDistance> _enemiesToAttackByDistance = new List<AttackByDistance>();
   
    private void Update()
    {
        for (int i = 0; i < _objectsToActivateByDistance.Count; i++)
        {
            _objectsToActivateByDistance[i].CheckDistance(_playerTransform.position);
            
        }

        for (int i = 0; i < _enemiesToAttackByDistance.Count; i++)
        {
            _enemiesToAttackByDistance[i].CheckDistance(_playerTransform.position);

        }
    }


    public void AddObjectToActivateByDistance(ActivateByDistance activateByDistance )
    {
        _objectsToActivateByDistance.Add(activateByDistance);
    }

    public void AddEnemyToAttackByDistance(AttackByDistance attackByDistance)
    {
        _enemiesToAttackByDistance.Add(attackByDistance);
    }


    public void RemoveObjectToActivateByDistance(ActivateByDistance activateByDistance)
    {
        _objectsToActivateByDistance.Remove(activateByDistance);
    }




    // класс вызывает метод CheckDistance, т.к в ActivateByDistance метод Deactivate() выключает объект и скрипт перестает работать
}
