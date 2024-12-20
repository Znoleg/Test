using UnityEngine;

//Комментарии убираемю
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float timeToTargetSpeed;
    

    private void Start()
    {
        //playerTransform = FindObjectOfType<Player>().transform;
    }

    //Метод нигде не вызывается, убрать его
    public void Init(Transform playerTransform)
    {
        _player = playerTransform;
    }

    private void FixedUpdate()
    {
        Vector2 toPlayer = (_player.position - transform.position).normalized;
        Vector2 force = rigidbody.mass * (toPlayer * speed - rigidbody.velocity) / timeToTargetSpeed;

        rigidbody.AddForce(force);
    }
}
