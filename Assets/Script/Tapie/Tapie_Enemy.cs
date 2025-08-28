using UnityEngine;

public class Tapie_Enemy : Enemy_Base
{
    [Header("총알 관련 설정")]
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject bulletPrefeb;
    
    public override void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefeb, transform.position, transform.rotation);
        Vector2 dir = player.transform.position - transform.position;
        bullet.GetComponent<Rigidbody2D>().AddForce(dir.normalized * bulletSpeed, ForceMode2D.Impulse);
    }
}
