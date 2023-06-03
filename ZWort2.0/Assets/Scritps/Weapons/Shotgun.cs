using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shotgun : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
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
        ammoCount.text = ammo.ToString() + "/8";

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (fireOn)
            {
                if (Input.GetButton("Fire1") && FindObjectOfType<Player>().canShot)
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
                            StartCoroutine(ReloadTimeCoroutine(12));
                        }
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

        GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        rb1.AddForce(firePoint1.right * bulletForce, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint2.right * bulletForce, ForceMode2D.Impulse);
    }

    private IEnumerator ReloadTimeCoroutine(float timeReload)
    {
        reloadColor.color = Color.red;
        yield return new WaitForSeconds(timeReload);
        reloadColor.color = Color.white;
        ammo = 8;
        ammoCount.text = ammo.ToString();
        fireOn = true;
    }
}
