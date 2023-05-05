using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    void Update()
    {
        if (health < 1)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            if (GameObject.Find("Player").GetComponent<Pistol>().enabled)
                health -= GameObject.Find("Player").GetComponent<Pistol>().damage;
            else if (GameObject.Find("Player").GetComponent<SubmachineGun>().enabled)
                health -= GameObject.Find("Player").GetComponent<SubmachineGun>().damage;
            else if (GameObject.Find("Player").GetComponent<AssaultRifles>().enabled)
                health -= GameObject.Find("Player").GetComponent<AssaultRifles>().damage;

            Destroy(collision.gameObject);
        }
    }
}
//health -= GameObject.Find("Player").GetComponent<Pistol>().damage;
//Destroy(collision.gameObject);
