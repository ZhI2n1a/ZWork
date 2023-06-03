using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyCount : MonoBehaviour
{
    Text text;
    public static int enemy;


    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = enemy.ToString();

        if (enemy == 500)
        {
            enemy = 0;
        }

    }
}
