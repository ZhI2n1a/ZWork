using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerPos;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5f, 5f), Mathf.Clamp(transform.position.y, -10f, 9f), transform.position.z);
    }
}
