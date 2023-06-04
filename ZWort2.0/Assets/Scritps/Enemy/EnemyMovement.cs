using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotatoinsSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerArenessControler _playerArenessControler;
    private Vector2 _targetDirection;

    private Animator moveAnim;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerArenessControler = GetComponent<PlayerArenessControler>();
        moveAnim = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_playerArenessControler.AwareOfPlayer)
            _targetDirection = _playerArenessControler.DirectionTopPlayer;
        else _targetDirection = Vector2.zero;
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
            return;

        Quaternion targetRootation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRootation, _rotatoinsSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidbody.velocity = Vector2.zero;
            moveAnim.SetBool("Moving", false);
        }
        else
        { 
            _rigidbody.velocity = transform.up * _speed;
            moveAnim.SetBool("Moving", true);
        }
    }
}
