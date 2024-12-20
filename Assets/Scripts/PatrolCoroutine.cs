using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

//Юзинги чистим, комментарии не оставляем.

//Никакая это не корутина, подумай лучше над названием. 
public class PatrolCoroutine : MonoBehaviour
{
    [SerializeField] private Transform leftTarget;
    [SerializeField] private Transform rightTarget;
    [SerializeField] float _speed;
    [SerializeField] float _stopTime = 0.3f;
    [SerializeField] private Transform _rayStart;

    private Transform finalTarget;
    private bool _isStopped;

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;

        finalTarget = leftTarget;

        //StartCoroutine(MoveBetweenPoints());
    }

    private void Update()
    {
        if (_isStopped) return;

        Move();

        if (transform.position.x == finalTarget.position.x)
        {
            _isStopped = true;
            Invoke("ContinuePatrol", _stopTime);

            if (finalTarget == leftTarget)
            {
                finalTarget = rightTarget;
            }
            else
            {
                finalTarget = leftTarget;
            }
        } 

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }


    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, finalTarget.position, _speed * Time.deltaTime);
    }

    private void ContinuePatrol()
    {
        _isStopped = false;
    }



    /*private IEnumerator MoveBetweenPoints()
    {
        while (true)
        {

        }
    } */
}
