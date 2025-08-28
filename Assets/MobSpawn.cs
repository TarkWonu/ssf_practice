using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnpos;
    [SerializeField] GameObject[] mobs;
    [SerializeField] float cooltime;

    GameObject monster;
    float t = 0;
    Transform player;

    void Start()
    {
        int index = (int)GameManager.instance.stage_level;
        monster = mobs[index];

        // 플레이어 오브젝트 찾기 (태그 기반 추천)
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player 오브젝트를 찾을 수 없습니다!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            spawnMob();
        }
    }

    void spawnMob()
    {
        t += Time.deltaTime;
        if (t >= cooltime)
        {
            t = 0;

            // 가장 가까운 스폰 위치 찾기
            Transform closest = spawnpos[0];
            float minDistance = Vector2.Distance(player.position, closest.position);

            foreach (Transform pos in spawnpos)
            {
                float dist = Vector2.Distance(player.position, pos.position);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    closest = pos;
                }
            }

            Instantiate(monster, closest.position, Quaternion.identity);
        }
    }
}
