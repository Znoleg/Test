using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    private Transform playerTransform;

    [SerializeField] private float speed;
    [SerializeField] private float timeToTargetSpeed;

    private void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
    }

    private void FixedUpdate()
    {
        Vector2 toPlayer = (playerTransform.position - transform.position).normalized;
        Vector2 force = rigidbody.mass * (toPlayer * speed - rigidbody.velocity) / timeToTargetSpeed;

        rigidbody.AddForce(force);
    }
}
