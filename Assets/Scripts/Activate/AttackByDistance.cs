using UnityEngine;

public class AttackByDistance : MonoBehaviour
{
    [SerializeField] private EnemyActivator _enemyActivator;
    [SerializeField] private float _distanceToAttack = 8f;
    private bool _isActiveToAttack = true;

    private void Start()
    {
        _enemyActivator.AddEnemyToAttackByDistance(this);
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (_isActiveToAttack)
        {
            if (distance > _distanceToAttack)
            {
                Deactivate();
            }
        }

        else
        {
            if (distance < _distanceToAttack)
            {
                Activate();
            }
        }
    }
    private void Activate()
    {
        _isActiveToAttack = true;
        gameObject.GetComponent<Enemy>().enabled = true;
    }

    private void Deactivate()
    {
        _isActiveToAttack = false;
        gameObject.GetComponent<Enemy>().enabled = false;
    }

}
