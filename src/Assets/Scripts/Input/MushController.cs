using UnityEngine;
using UnityEngine.InputSystem;

public class MushController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotationSensitivity = 5;
    private Rigidbody _rb;
    private Transform _transform;
    private Vector3 _impulse;
    private Vector3 _movement;
    private Vector3 _rotation;

    private Vector3 _respawnPosition;

    public Vector3 Movement
    {
        get { return _movement; }
    }

    public Vector3 Rotation
    {
        get { return _rotation; }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _respawnPosition = transform.position;
        Respawn.NeedRespawn += RespawnPlayer;
    }

    private void RespawnPlayer()
    {
        print("Is reapning");
        _transform.position = _respawnPosition;
        _rb.velocity = new Vector3();
    }

    private void FixedUpdate()
    {
        _transform.Rotate(Vector3.up, _rotation.x * _rotationSensitivity);
        _movement = _transform.TransformDirection(_impulse);
        _rb.AddForce(_movement * _speed);
    }

    public void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        _impulse = new Vector3(inputVector.x, 0, inputVector.y);
    }

    public void OnLook(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        _rotation = new Vector3(inputVector.x, 0, inputVector.y);        
    }

    public void OnJump(InputValue value)
    {
        _rb.AddForce(new Vector3(0, _jumpForce, 0));
    }
}
