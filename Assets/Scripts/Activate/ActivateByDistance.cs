using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] private EnemyActivator _enemyActivator;
    [SerializeField] private float _distanceToActivate = 18f;
    private bool _isActive = true;
    

    private void Start()
    {
        // добавил объекты в List в инспекторе

        //_enemyActivator = FindObjectOfType<EnemyActivator>();

        _enemyActivator.AddObjectToActivateByDistance(this);
    }
    
    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (_isActive)
        {
            if (distance > _distanceToActivate + 2f) // исчезать enemy будет немнго дальше _distanceToActivate, чтобы избежать некорректного поведения объекта
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
