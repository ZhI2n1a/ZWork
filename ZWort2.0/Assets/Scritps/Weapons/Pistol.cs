using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource fireSound;
    public Text ammoCount;
    public Graphic reloadColor;

    public float bulletForce;
    public float firRate;
    public float damage;
    public int ammo;

    private float nextTimeOffFire = 0f;
    private bool fireOn = true;

    void Update()
    {
        ammoCount.text = ammo.ToString();
        if (fireOn)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (Time.time >= nextTimeOffFire)
                {
                    Shoot();
                    nextTimeOffFire = Time.time + 1 / firRate;
                    fireSound.Play();
                    ammo -= 1;

                    if (ammo == 0)
                    {
                        fireOn = false;
                        StartCoroutine(ReloadTimeCoroutine(4));
                    }
                }
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    private IEnumerator ReloadTimeCoroutine(float timeReload)
    {
        reloadColor.color = Color.red;
        yield return new WaitForSeconds(timeReload);
        reloadColor.color = Color.white;
        ammo = 7;
        ammoCount.text = ammo.ToString();
        fireOn = true;
    }
}

