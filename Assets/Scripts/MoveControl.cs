using UnityEngine;

public class MoveControl : MonoBehaviour
{
    private static readonly string idle = "player_idle";
    private static readonly string run = "player_run";
    private static readonly string jump = "player_jump";

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGrounded;

    
    
    private void Update()
    {
        if (_isGrounded)
        {
            _animator.Play(idle);
        }

        if (!_isGrounded)
        {
            _animator.Play(jump);
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
        if (_isGrounded)
        {
            _animator.Play(run);
            //State = States.run;
        }

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * _moveSpeed);

        _sprite.flipX = direction.x < 0f;
    }

    public void Jump()
    { 
        if (_isGrounded)
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
       
    private void OnCollisionStay2D(Collision2D collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (angle < 45f)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D()
    {
        _isGrounded = false;
    }

}
