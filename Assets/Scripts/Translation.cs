using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Directon
{
    Left,
    Right
}
public class Translation : MonoBehaviour
{
    [SerializeField] Transform leftTarget;
    [SerializeField] Transform rightTarget;

    [SerializeField] float speed;

    [SerializeField] float stopTime;

    [SerializeField] Directon currentDirecton;

    [SerializeField] private Transform RayStart;

    private bool isStopped;

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;
    }

    private void Update()
    {
        if (isStopped) return;

        if (currentDirecton == Directon.Left)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);

            if (transform.position.x < leftTarget.position.x)
            {
                currentDirecton = Directon.Right;
                isStopped = true;
                Invoke("ContinueGo", stopTime);
            }
        }
        else
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);

            if (transform.position.x > rightTarget.position.x)
            {
                currentDirecton = Directon.Left;
                isStopped = true;
                Invoke("ContinueGo", stopTime);
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
        isStopped = false;
    }
}
