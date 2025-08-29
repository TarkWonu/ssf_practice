using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 25f;
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            Boss_base boss = other.GetComponent<Boss_base>();
            if (boss != null)
            {
                boss.TakeDamage(GameManager.instance.bulletdamage);
            }
            Destroy(gameObject);
        }

        

        if (other.CompareTag("Mob"))
        {
            Enemy_Base enemy = other.GetComponent<Enemy_Base>();
            if (enemy != null)
            {
                enemy.TakeDamage(GameManager.instance.bulletdamage);
            }
            Destroy(gameObject);
        }
    }
}

