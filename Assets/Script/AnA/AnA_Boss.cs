using UnityEngine;
using System.Collections;

public class AnA_Boss : Boss_base
{
    [SerializeField] GameObject Laser;
    [SerializeField] GameObject boom;

    public GameObject player;

    public float moveSpeed = 2f;
    public float stopDistance = 2f;

    [SerializeField] float laserRotateSpeed;
    [SerializeField] GameObject[] Servers;
    bool server_enable;
    float healtimer = 0;
    float healcooltime;
    float attacktimer;
    bool attacking;
    private Vector3 previousPosition;
    private float currentSpeed;
    [SerializeField] float attackcooltime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathanimlength = 0.75f;
        anim = GetComponent<Animator>();
        Laser.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Player 오브젝트를 찾을 수 없습니다. 'Player' 태그를 확인하세요.");
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (!attacking) { attacktimer += Time.deltaTime; FollowPlayer();}
        UpdateAnimation();
        healcooltime += Time.deltaTime;
        if (attacktimer >= attackcooltime)
        {
            attacktimer = 0;
            int attackevent = Random.Range(1, 3);

            switch (attackevent)
            {
                case 1:
                    {
                        StartCoroutine(LaserRotate());
                        break;
                    }
                case 2:
                    {
                        StartCoroutine(DrawBoom());
                        break;
                    }
            }
        }
        /* if (healcooltime >= 10f && boss_hp < boss_maxhp / 2)//보스 체력 1/2이하
        {
            healcooltime = 0;
            SpawnServer();
        }


        Server_Heal();
    */
    }
    void FollowPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.z = 0f;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = direction.x < 0;
        }

        if (direction.magnitude > stopDistance)
        {
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        }
    }

    void UpdateAnimation()
    {
        currentSpeed = ((transform.position - previousPosition) / Time.deltaTime).magnitude;
        previousPosition = transform.position;

        if (anim != null)
        {
            anim.SetFloat("Speed", currentSpeed);
        }
    }
    

    IEnumerator LaserRotate()
    {
        attacking = true;
        Laser.SetActive(true);
        //float timeElapsed = 0f;
        float currentRotation = 0f;

        while (currentRotation < 360f)
        {
            float deltaRotation = (360f / laserRotateSpeed) * Time.deltaTime;
            Laser.transform.Rotate(0f, 0f, deltaRotation);
            currentRotation += deltaRotation;
        
            yield return null;
        }


        float correction = 360f - currentRotation;
        Laser.transform.Rotate(0f, 0f, correction);
        Laser.SetActive(false);
        attacking = false;
    }



    void SpawnServer()
    {
        foreach (var s in Servers)
        {
            s.SetActive(true);
        }
    }


    /* void Server_Heal()
    {
        server_enable = false;
        foreach (var i in Servers)
        {
            if (i.activeSelf)
            {
                server_enable = true;
            }
        } 



        if (server_enable)
        {
            healtimer += Time.deltaTime;
            if (healtimer >= 1.5f)
            {
                boss_hp++;
                healtimer = 0;
            }
        }
    }*/

    IEnumerator DrawBoom()
    {
        attacking = true;
        for (int i = 0; i < 6; i++)
        {
            Instantiate(boom, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        attacking = false;
    }
    


}
