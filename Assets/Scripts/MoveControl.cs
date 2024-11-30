using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum States
{
    idle,
    run,
    jump
}
public class MoveControl : MonoBehaviour
{
    //[SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;

    private States State
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }
    
    private void Update()
    {
        if (isGrounded)
        {
            State = States.idle;
        }

        if (!isGrounded)
        {
            State = States.jump;
        }

        if (Input.GetButton("Horizontal"))
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move()
    {
        if (isGrounded)
        {
            State = States.run;
        }

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * moveSpeed);

        sprite.flipX = direction.x < 0f;


    }

    public void Jump()
    { 
        if (isGrounded)
        {
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        
    }
       
    private void OnCollisionStay2D(Collision2D collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (angle < 45f)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}
