using System.Collections.Generic;
using UnityEngine;

//У тебя с компонентом ActivateByDistance и AttackByDistance получается циклическая зависимость.
//То есть у тебя EnemyActivator ссылается на ActivateByDistance и AttackByDistance, а ActivateByDistance и AttackByDistance ссылается на EnemyActivator.
//Как минимум, это надо убирать Вообще правило на всю жизнь: чем меньше класс знает о ком то, тем лучше 
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




    // ����� �������� ����� CheckDistance, �.� � ActivateByDistance ����� Deactivate() ��������� ������ � ������ ��������� ��������
}
