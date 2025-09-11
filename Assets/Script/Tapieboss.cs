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

    void DoRangedAttack(Vector2 dir)
    {
        //코드 작성 해주세요!
    }

    void DoMeleeAttackOrChase(Vector2 dir)
    {
        if (Vector3.Distance(player.position, transform.position) < 2f)
        {
            //코드 작성 해주세요!
        }
        else
        {
            //코드 작성 해주세요!
            anim.SetBool("Moving", true);
            if (walktime > 0f)
            {
                walktime -= Time.deltaTime;
            }
            else { walktime = 0f; bulletcount = 0; currentaction = 0; anim.SetBool("Moving", false); }
        }
    }
    void SummonAds()
    {
        //코드 작성 해주세요!
    }

    #region 
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
            anim.SetFloat("dirx", dir.x);
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
            case 2: walktime = 2f; bulletcount = 3; break;
            case 3: bulletcount = Random.Range(4, 6); break;
        }
        wait = Random.Range(0.5f, 2f);
    }
    #endregion

    

    
}