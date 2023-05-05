using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTime;

    private void Start()
    {
        StartCoroutine(BulletDestroy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            //Destroy(collision.gameObject);
            //Destroy(gameObject);
        }
    }

    private IEnumerator BulletDestroy()
    {
        yield return new WaitForSecondsRealtime(destroyTime);
        Destroy(gameObject);
    }
}
