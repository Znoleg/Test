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

    //По сути полное дублирование метода из ActivateByDistance. Подумать, как решить без дублирования. 
    //Кроме того, нечитаемая сигнатура метода. Когда я вижу название CheckDistance, я ожидаю только проверку дистанции.
    //А под капотом у этого метода заложена еще какая-то логика с активированием. 
    //Ну и само название подразумевает возвращение некоего значения дистанции, а не void
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
