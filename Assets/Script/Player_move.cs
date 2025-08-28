using UnityEngine;

public class Player_move : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()

    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = 
        new Vector2(x, y).normalized * speed;
    }
}
