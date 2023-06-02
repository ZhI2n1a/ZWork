using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AssaultRifles : MonoBehaviour
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
        ammoCount.text = ammo.ToString() + "/21";

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (fireOn)
            {
                if (Input.GetButton("Fire1"))
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
                            StartCoroutine(ReloadTimeCoroutine(16));
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
    }
    private IEnumerator ReloadTimeCoroutine(float timeReload)
    {
        reloadColor.color = Color.red;
        yield return new WaitForSeconds(timeReload);
        reloadColor.color = Color.white;
        ammo = 20;
        ammoCount.text = ammo.ToString();
        fireOn = true;
    }
}
