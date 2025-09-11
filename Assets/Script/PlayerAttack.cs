using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireCooldown = 0.5f;
    private float fireTimer = 0f;
    public bool reloading;
    public int ammo;


    void Update()
    {
        //코드 작성 해주세요!
    }
    #region 
    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(5f);
        reloading = false;
        ammo = GameManager.instance.maxammo;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    #endregion
}
