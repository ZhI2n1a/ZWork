using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArenessControler : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionTopPlayer { get; private set; }

    [SerializeField]
    private float _platerAwarenessDistancel;

    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>().transform; 
    }
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionTopPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _platerAwarenessDistancel)
            AwareOfPlayer = true;
        else AwareOfPlayer = false;
    }
}
