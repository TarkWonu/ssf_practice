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
        fireTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && fireTimer <= 0f && ammo > 0)
        {
            Shoot();
            ammo--;
            fireTimer = fireCooldown;
        }

        if (Input.GetKeyDown(KeyCode.R)&&!reloading)
        {
            StartCoroutine(Reload());
        }
    }

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
}
