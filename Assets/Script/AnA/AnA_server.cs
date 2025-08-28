using UnityEngine;

public class AnA_server : Enemy_Base
{
    void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (health <= 0) Destroy(gameObject);
    }
}
