using System.Collections;
using UnityEngine;

public class AnA_Enemy : Enemy_Base
{
    [SerializeField] float boomDistance;
    // Update is called once per frame

    Animator anim;

    void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

        private IEnumerator BoomAfterAnimation()
    {
        // 사망 애니메이션 길이에 맞춰서 대기 
        yield return new WaitForSeconds(0.4f);
        GameManager.instance.TakeDamage(damage);
        Destroy(gameObject);
    }

    public override void Attack()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        if (Vector2.Distance(transform.position, player.transform.position) < 3)
        {
            anim.SetTrigger("Explode");
            StartCoroutine(BoomAfterAnimation());
        }
    }
}
