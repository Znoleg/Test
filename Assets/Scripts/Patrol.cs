using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Юзинги чистим.

public enum Directon
{
    Left,
    Right
}
public class Patrol : MonoBehaviour
{
    //Тут пробелы вообще не нужны, пусть подряд все [SerializeField] идут, иначе просто класс распухает
    [SerializeField] private Transform leftTarget;
    [SerializeField] private Transform rightTarget;

    [SerializeField] float _speed;

    [SerializeField] float _stopTime;

    [SerializeField] Directon _currentDirecton;

    [SerializeField] private Transform _rayStart;

    private bool _isStopped;

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;
    }

    private void Update()
    {
        if (_isStopped) return;

        //Вынести в один метод с разными параметрами всё, что под if/else, тк явный дубляж кода
        if (_currentDirecton == Directon.Left)
        {
            transform.position -= new Vector3(_speed * Time.deltaTime, 0f, 0f);

            if (transform.position.x < leftTarget.position.x)
            {
                _currentDirecton = Directon.Right;
                _isStopped = true;
                Invoke("ContinueGo", _stopTime);
            }
        }
        else
        {
            transform.position += new Vector3(_speed * Time.deltaTime, 0f, 0f);

            if (transform.position.x > rightTarget.position.x)
            {
                _currentDirecton = Directon.Left;
                _isStopped = true;
                Invoke("ContinueGo", _stopTime);
            }
        }

        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    //Название непонятное, лучше что-то вроде SetMoveStatus на крайняк
    private void ContinueGo()
    {
        _isStopped = false;
    }

    //Метод нигде не вызывается, убрать
    private void Move()
    {
        Transform target = leftTarget;

        if (transform.position.x == leftTarget.position.x)
        {
            target = rightTarget;
        }
        else
        {
            target = leftTarget;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }
}
