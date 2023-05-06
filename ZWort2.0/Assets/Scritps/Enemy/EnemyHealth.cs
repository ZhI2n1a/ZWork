using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    void Update()
    {
        if (health < 1)
        {
            enemyCount.enemy += 1;
            Destroy(gameObject);
        }

        if (GameObject.Find("Player").GetComponent<Player>().enabled)
        { }
        else enemyCount.enemy = 0;

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
            else if (GameObject.Find("Player").GetComponent<Shotgun>().enabled)
                health -= GameObject.Find("Player").GetComponent<Shotgun>().damage;
            else if (GameObject.Find("Player").GetComponent<SniperRifle>().enabled)
                health -= GameObject.Find("Player").GetComponent<SniperRifle>().damage;
            else if (GameObject.Find("Player").GetComponent<MachineGun>().enabled)
                health -= GameObject.Find("Player").GetComponent<MachineGun>().damage;

            Destroy(collision.gameObject);
        }
    }
}
//health -= GameObject.Find("Player").GetComponent<Pistol>().damage;
//Destroy(collision.gameObject);
