using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Tapieboss : Boss_base
{
    public Rigidbody2D rb;
    Transform player;
    public int currentaction = 0;
    int bulletcount = 0;
    public float wait = 0, movespeed = 15f, walktime = 0;
    public GameObject bulletPrefab, meleePrefab, adPrefab;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        deathanimlength = 1.15f;
    }

    public override void Update()
    {
        base.Update();
        if (wait > 0f)
        {
            wait -= Time.deltaTime;
        }
        else
        {
            wait = 0f;
            Vector2 dir = (player.position - transform.position).normalized;
            anim.SetFloat("dirx",dir.x);
            anim.SetFloat("diry", dir.y);

            switch (currentaction)
            {
                case 0:
                    InitAction();
                    break;
                case 1:
                    DoRangedAttack(dir);
                    break;
                case 2:
                    DoMeleeAttackOrChase(dir);
                    break;
                case 3:
                    SummonAds();
                    break;
            }
        }
    }

    void InitAction()
    {
        currentaction = Random.Range(1, 4);
        switch (currentaction)
        {
            case 1: bulletcount = Random.Range(3, 7); break;
            case 2: walktime=2f; bulletcount = 3; break;
            case 3: bulletcount = Random.Range(4, 6); break;
        }
        wait = Random.Range(0.5f, 2f);
    }

    void DoRangedAttack(Vector2 dir)
    {
        if (bulletcount > 0)
        {
            GameObject instance = Instantiate(bulletPrefab, transform.position, Quaternion.FromToRotation(Vector3.right, dir));
            Destroy(instance, 2f);
            bulletcount--;
            wait = 0.5f;
        }
        else
        {
            currentaction = 0;
        }
    }

    void DoMeleeAttackOrChase(Vector2 dir)
    {
        if (Vector3.Distance(player.position, transform.position) < 2f)
        {
            anim.SetBool("Moving", false);
            if (bulletcount > 0)
            {
                GameObject instance = Instantiate(meleePrefab, transform.position, Quaternion.FromToRotation(Vector3.right, dir));
                Destroy(instance, 0.15f);
                bulletcount--;
                wait = 0.5f;
            }
            if (bulletcount == 0)
                currentaction = 0;
        }
        else
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(direction * movespeed + rb.position);
            anim.SetBool("Moving", true);
            if (walktime > 0f)
            {
                walktime -= Time.deltaTime;
            }
            else { walktime = 0f; bulletcount = 0; currentaction = 0; anim.SetBool("Moving", false);}
        }
    }

    void SummonAds()
    {
        if (bulletcount > 0)
        {
            GameObject instance = Instantiate(adPrefab, new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f)), Quaternion.LookRotation(Vector3.forward));
            bulletcount--;
            wait = Random.Range(0.5f, 1f);
        }
        else
        {
            currentaction = 0;
        }
    }
}