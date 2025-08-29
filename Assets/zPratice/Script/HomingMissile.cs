using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float speed = 4f;              // 유도탄 속도
    public float rotateSpeed = 200f;      // 회전 속도
    public float lifetime = 10f;          // 자동 삭제 시간

    [HideInInspector]
    public Transform target;              // 추적 대상 

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime); 
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.linearVelocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.player_hp--;   
            Destroy(gameObject);
        }
    }
}


