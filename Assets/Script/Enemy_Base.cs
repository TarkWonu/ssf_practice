using UnityEngine;
using System;

public class Enemy_Base : MonoBehaviour


{

    private enum State { Idle, Follow, Attack, Hurt, Die }

    public GameObject player,coin;
    float i = 0;
    [Header("기본 속성")]
    public int health;
    public int damage;
    public float moveSpeed;
    [Header("감지 범위")]
    public float StartFollowDistance;

    private Animator animator;

    public float stopDistance;//이 범위 안에오면 다가오지 않음(원거리는 거리를 둬야하니까)
    [Header("쿨타임")]
    public float attackCooltime;
    int max_health;
    public event Action<float, float> OnHealthChanged;

    [SerializeField]
    private State _state;

    void Awake()
    {
        
        max_health = health;
    }

    public void FollowPlayer()
    {
        
        //코드 작성 해주세요!
    }
    #region 
    protected void Start()
    {
        player = GameObject.Find("Player");
        _state = State.Idle;
        i = attackCooltime;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AvoidOtherEnemies();
        switch (_state)
        {
            case State.Idle:

                if (Vector2.Distance(transform.position, player.transform.position) < StartFollowDistance)
                {
                    ChangeState(State.Follow);
                }
                break;

            case State.Follow:

                // 플레이어와 적의 상대 위치 계산
                Vector2 direction = player.transform.position - transform.position;

                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    if (direction.x > 0)
                    {
                        spriteRenderer.flipX = true;
                    }
                    else if (direction.x < 0)
                    {
                        spriteRenderer.flipX = false;
                    }
                }

                FollowPlayer();
                if (Vector2.Distance(transform.position, player.transform.position) < stopDistance)
                {
                    ChangeState(State.Attack);
                }
                
                break;

            case State.Attack:
                //Attack Animation Trigger 
                AttackSystem();
                break;
            case State.Hurt:
                //Attack Animation Trigger 

                if (health <= 0)
                {
                    ChangeState(State.Die);
                }
                else
                {
                    OnHealthChanged?.Invoke(health, max_health);
                    ChangeState(State.Idle);
                }

                break;

            case State.Die:
                //Die Animaion Trigger
                if(UnityEngine.Random.Range(0,2)==0)Instantiate(coin, transform.position, Quaternion.LookRotation(Vector3.forward));
                Destroy(gameObject);
                break;

        }
    }




    public virtual void Attack() { }



    

    

    public void AttackSystem()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < stopDistance)
        {

            i += Time.deltaTime;
            if (i > attackCooltime)
            {
                i = 0f;
                Attack();

            }
        }
        else { i = 0; ChangeState(State.Idle); }
    }

    public void TakeDamage(int d)
    {
        health -= d;
        ChangeState(State.Hurt);
        
    }

    void AvoidOtherEnemies()
    {
        Collider2D[] others = Physics2D.OverlapCircleAll(transform.position, 0.5f, LayerMask.GetMask("Enemy"));
        foreach (var other in others)
        {
            if (other.gameObject != gameObject)
            {
                Vector2 directionAway = (transform.position - other.transform.position).normalized;
                transform.position += (Vector3)(directionAway * 0.01f);
            }
        }
    }

    void ChangeState(State s)
    {
        _state = s;

        if (animator == null) return;

        if (s == State.Follow)
        {
            animator.SetTrigger("Follow");
        }

        if (s == State.Die)
        {
            animator.SetTrigger("Dead");
        }

    }
    #endregion

}
