using System.Collections;
using UnityEngine;

public class AnA_Enemy : Enemy_Base
{
    [SerializeField] float boomDistance;
    // Update is called once per frame

    Animator anim;
    public override void Attack()
    {
        //코드 작성 해주세요!
    }
    private IEnumerator BoomAfterAnimation()
    {
        // 사망 애니메이션 길이에 맞춰서 대기 
        yield return new WaitForSeconds(0.4f);
        GameManager.instance.TakeDamage(damage);
        Destroy(gameObject);
    }
    void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    

    
}
