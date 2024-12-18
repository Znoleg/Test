using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Directon
{
    Left,
    Right
}
public class Patrol : MonoBehaviour
{
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

    private void ContinueGo()
    {
        _isStopped = false;
    }

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
