using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (enemy == 1000)
        {
            enemy = 0;
        }
    }
}
