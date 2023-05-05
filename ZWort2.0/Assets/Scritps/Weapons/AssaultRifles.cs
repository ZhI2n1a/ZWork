using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifles : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;


    public float bulletForce = 20f;
    public float firRate = 1;
    public float damage = 20;

    private float nextTimeOffFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time >= nextTimeOffFire)
            {
                Shoot();
                nextTimeOffFire = Time.time + 1 / firRate;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
