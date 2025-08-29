using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 5;
    private int currentHP;
    public bool isDead = false;
    Animator anim;

    void Start()
    {
        currentHP = maxHP;
        anim = GetComponent<Animator>();
    }

    private IEnumerator DieAfterAnimation()
    {
        // 사망 애니메이션 길이에 맞춰서 대기 
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHP -= damage;
        if (currentHP <= 0)
        {
            isDead = true;
            anim.SetTrigger("Dead");
            StartCoroutine(DieAfterAnimation());
        }
    }
}
