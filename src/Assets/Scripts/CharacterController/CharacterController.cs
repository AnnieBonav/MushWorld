using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _lookSensitivity = 8f;
    [SerializeField] private float _moveArmSensitivity = 1;
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rb;
    private Transform _transform;
    private Vector3 _impulse;
    private Vector3 _movement;
    private Vector3 _rotation;

    private Vector3 _respawnPosition;

    private bool _isMoving;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _respawnPosition = transform.position;
        Respawn.NeedRespawn += RespawnPlayer;
    }

    private void RespawnPlayer()
    {
        print("Is respawning");
        _transform.position = _respawnPosition;
        _rb.velocity = new Vector3();
    }

    private void FixedUpdate()
    {
        _transform.Rotate(Vector3.up, _rotation.x * _lookSensitivity);
        HandleMove();
    }

    public void OnMove(InputValue value)
    {
        _isMoving = value.isPressed;
    }

    private void HandleMove()
    {
        _movement = _transform.TransformDirection(_impulse);
        print("Movement: " + _movement + "  Impulse: " + _impulse + " Speed: " + _moveSpeed);
        _rb.AddForce(_movement * _moveSpeed);
    }

    public void OnLook(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        _rotation = new Vector3(inputVector.x, 0, inputVector.y);
        _impulse = new Vector3(inputVector.x, 0, inputVector.y);
    }

    public void OnMoveHand(InputValue value)
    {
        print("Moving hand: " + value.Get<Vector2>());
    }

    public void OnJump(InputValue value)
    {
        _rb.AddForce(new Vector3(0, _jumpForce, 0));
    }
}
