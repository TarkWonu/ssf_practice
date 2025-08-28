using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public enum Stage{para,ana,tapie}
public class GameManager : MonoBehaviour

{

    private Animator playerAnimator;

    public static GameManager instance;
    public Stage stage_level;


    
    public int player_hp;
    public int player_maxhp;


    public int maxammo = 5;
    public int coin;
    public int bulletdamage = 1;


    private bool isInvincible = false;
    public float invincibleDuration = 1.0f; // 무적 시간



    void Awake()
    {

        

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);

        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // 구독
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 해제
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerAnimator = player.GetComponent<Animator>();
        }   
    }

    public bool isDead = false;

    private IEnumerator HandlePlayerDeath()
    {
        if (isDead) yield break; // 중복 실행 방지
        isDead = true;

        if (playerAnimator != null)
        {
            Debug.Log("사망");
            playerAnimator.SetTrigger("Dead"); // 애니메이션 실행
        }

        yield return new WaitForSeconds(2.5f); // 애니메이션 길이만큼 대기

        FadeManager.Instance.LoadScene("Die");
    }

    void Update()
    {
        
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        // 여기에 무적상태 시각적으로 보여주는 효과 추가가능.
        Debug.Log("플레이어 무적");
        yield return new WaitForSeconds(invincibleDuration);
        isInvincible = false;
        Debug.Log("플레이어 무적 풀림.");
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            player_hp -= damage;
            if (player_hp <= 0)
            {
                StartCoroutine(HandlePlayerDeath());
            }
            StartCoroutine(PlayerHitAnimation());
            StartCoroutine(InvincibilityCoroutine()); // 무적 코루틴 시작
        }
    }


    private IEnumerator PlayerHitAnimation()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            player.GetComponent<SpriteRenderer>().color = new Color(255/255f,134/255f,134/255f);

        }
        yield return new WaitForSeconds(0.1f);
        if (player != null)
        {
            player.GetComponent<SpriteRenderer>().color = new Color (1,1,1);

        }
    }


    public void MoveStage()
    {
        if (stage_level < Stage.tapie)
        {
        stage_level++;
        FadeManager.Instance.LoadScene("Shop");
        }
        else
        {
            FadeManager.Instance.LoadScene("Clear");
        }



    }

    public void GameStart()
    {
        FadeManager.Instance.LoadScene("Stage");
    }
    
    
}
