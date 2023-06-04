using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInpunSmoothVelocity;

    private Animator moveAnim;
    private Animator legsAnim;

    public AudioSource moveSound;

    public Joystick moveJoystick;
    public Joystick shootJoystick;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        moveAnim = transform.GetChild(0).GetComponent<Animator>();
        legsAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 || Mathf.Abs(Input.GetAxis("Vertical")) > 0 || moveJoystick.InputDir != Vector3.zero)
        {
            moveAnim.SetBool("Moving", true);
            legsAnim.SetBool("MoveLegs", true);

            if (moveSound.isPlaying) return;
            moveSound.Play();
        }
        else
        {
            moveAnim.SetBool("Moving", false);
            legsAnim.SetBool("MoveLegs", false);
            moveSound.Stop();
        }
    }

    private void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -11.5f, 11.5f), Mathf.Clamp(transform.position.y, -11.5f, 11.5f));
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movementInput, ref _movementInpunSmoothVelocity, 0.1f);
        if (moveJoystick.InputDir != Vector3.zero)
            _smoothedMovementInput = moveJoystick.InputDir;
        _rigidbody.velocity = _smoothedMovementInput * _speed;

    }

    private void RotateInDirectionOfInput()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (shootJoystick.InputDir != Vector3.zero)
            angle = Mathf.Atan2(shootJoystick.InputDir.y, shootJoystick.InputDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
