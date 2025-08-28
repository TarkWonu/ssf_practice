using UnityEngine;
using TMPro;
using System.Collections;
using NUnit.Framework;
public class Boss_base : MonoBehaviour
{

    public int boss_hp;
    public int boss_maxhp;
    public float deathanimlength=1.6f;

    private bool isDead = false;

    protected Animator anim;

    [SerializeField] GameObject Door;
    

    void Start()
    {
        boss_hp = boss_maxhp;
        Door.SetActive(false);

    }

    public virtual void Update()
    {
        if(boss_hp>boss_maxhp){ boss_hp = boss_maxhp;}
        
        if (isDead != true)
        {
            Boss_Die(); 
        }
        
    }

    public void TakeDamage(int damage)
    {
        boss_hp -= damage;

    }

    private IEnumerator DieAfterAnimation()
    {
        // 사망 애니메이션 길이에 맞춰서 대기 
        yield return new WaitForSeconds(deathanimlength);
        Destroy(gameObject);
    }

    void Boss_Die()
    {
        if (boss_hp <= 0)
        {
            isDead = true;
            Door.SetActive(true);
            anim.SetTrigger("Dead");
            StartCoroutine(DieAfterAnimation());
        }
    }

    
}
