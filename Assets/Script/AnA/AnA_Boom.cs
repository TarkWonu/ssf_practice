using UnityEngine;

public class AnA_Boom : MonoBehaviour
{
    
    [SerializeField] float boomSpeed;
    float boomtimer;
    [SerializeField] GameObject boomprefeb;
    Vector2 playerPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPos = GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        boomtimer+=Time.deltaTime;
        if (boomtimer >= 3f)
        {
            GameObject boomradius = Instantiate(boomprefeb, transform.position, Quaternion.identity);
            Destroy(boomradius, 0.5f);
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, playerPos, boomSpeed * Time.deltaTime);
    }
}
