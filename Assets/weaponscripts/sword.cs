using UnityEngine;

public class sword : MonoBehaviour
{
    public float speed = 10f, destroyTime = 2f , start = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * start);
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob"))
        {
            Destroy(gameObject);
        }
    }
}
