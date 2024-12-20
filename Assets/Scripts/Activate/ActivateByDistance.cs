using UnityEngine;

//Следить за отступами в коде, сохраняя единую консистентность. А то в одном месте нет отступа, в другом 2, в третьем 1
//Оставлять любые комментарии - харам в 99 процентах случаев. Чтобы что-то вернуть как было, используй гит. Он как раз для этого
//НИКОГДА не называть классы глаголом, ТОЛЬКО существительным
public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] private EnemyActivator _enemyActivator;
    [SerializeField] private float _distanceToActivate = 18f;
    private bool _isActive = true;
    

    private void Start()
    {
        // ������� ������� � List � ����������

        //_enemyActivator = FindObjectOfType<EnemyActivator>();

        _enemyActivator.AddObjectToActivateByDistance(this);
    }
    
    public void CheckDistance(Vector3 playerPosition)
    {
        //Лучше на активирование сразу проверять, иначе у тебя расстояние может впустую посчитаться, и потом ничего не произойдет
        //Экономим ресурсы машины таким образом.
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (_isActive)
        {
            //Магических чисел избегаем. Вынеси двойку в сериализуемое поле вверху класса
            if (distance > _distanceToActivate + 2f) // �������� enemy ����� ������ ������ _distanceToActivate, ����� �������� ������������� ��������� �������
            {
                Deactivate();
            } 
        }

        else
        {
            if (distance < _distanceToActivate)
            {
                Activate();
            }
        }
    }
    
    //Подумать, как избавиться от методов активирования и деактивирования. У монобехов и без того есть SetActive, который
    //можно вызывать в любом месте. 
    private void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        //_enemyActivator.ObjectsToActivate.Remove(this);

        _enemyActivator.RemoveObjectToActivateByDistance(this);
    }
}
