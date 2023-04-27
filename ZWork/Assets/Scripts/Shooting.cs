using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    //public Button pistol;
    //public bool pistolActivate;

    //public Button smg;
    //public bool smgActivate;

    //public Button shotguns;
    //public bool shootgnsActivate;

    //public Button rifiles;
    //public bool rifilesActivate;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
        //Destroy(Instantiate(bulletPrefab, transform.position, Quaternion.identity), 5f);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

}
