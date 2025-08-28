using UnityEngine;

public class Para_boss : Boss_base
{
    public GameObject player;
    public GameObject mobPrefab;
    public GameObject missilePrefab;
    public Transform firePoint;

    public float mobSpawnInterval = 5f;
    public float missileFireInterval = 3f;
    public float moveSpeed = 2f;
    public float stopDistance = 2f;

    private float mobTimer;
    private float missileTimer;

    // 추적 타이머
    private float moveCycleTimer = 0f;
    private bool isMoving = true;
    private float moveDuration = 3f;
    private float restDuration = 2f;

    private Vector3 previousPosition;
    private float currentSpeed;

    void Start()
    {
        deathanimlength = 1.16f;
        mobTimer = mobSpawnInterval;
        missileTimer = missileFireInterval;
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Player 오브젝트를 찾을 수 없습니다. 'Player' 태그를 확인하세요.");
        }

        previousPosition = transform.position;
    }

    public override void Update()
    {

        base.Update();

        if (boss_hp <= 0) return;

        UpdateMovementCycle();

        if (player != null && isMoving)
        {
            FollowPlayer();
        }

        UpdateAnimation();

        mobTimer -= Time.deltaTime;
        missileTimer -= Time.deltaTime;

        if (mobTimer <= 0f)
        {
            SpawnMob();
            mobTimer = mobSpawnInterval;
        }

        if (missileTimer <= 0f)
        {
            FireMissile();
            missileTimer = missileFireInterval;
        }
    }

    void UpdateMovementCycle()
    {
        moveCycleTimer += Time.deltaTime;

        if (isMoving && moveCycleTimer >= moveDuration)
        {
            isMoving = false;
            moveCycleTimer = 0f;
        }
        else if (!isMoving && moveCycleTimer >= restDuration)
        {
            isMoving = true;
            moveCycleTimer = 0f;
        }
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

    void SpawnMob()
    {
        int currentMobCount = GameObject.FindGameObjectsWithTag("Mob").Length;
        if (currentMobCount >= 6) return;

        Vector2 offset = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
        Instantiate(mobPrefab, (Vector2)transform.position + offset, Quaternion.identity);
    }

    void FireMissile()
    {
        if (player == null) return;

        GameObject missileObj = Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
        HomingMissile missile = missileObj.GetComponent<HomingMissile>();

        if (missile != null)
        {
            missile.target = player.transform;
        }
    }
}




