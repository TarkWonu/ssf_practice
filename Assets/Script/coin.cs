using UnityEngine;

public class coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.coin++;
            Destroy(gameObject);
        }
    }
}
