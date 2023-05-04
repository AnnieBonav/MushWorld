using UnityEngine;
using UnityEngine.InputSystem;

public class MushController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotationSensitivity = 5;
    private Rigidbody _rb;
    private Transform _transform;
    private Vector3 _movement;
    private Vector3 _rotation;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_movement * _speed);
        _transform.Rotate(Vector3.up, _rotation.x * _rotationSensitivity);
    }

    public void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        _movement = new Vector3(inputVector.x, 0, inputVector.y);
    }

    public void OnLook(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        Debug.Log("Input value look: " + inputVector);
        _rotation = new Vector3(inputVector.x, 0, inputVector.y);        
    }

    public void OnJump(InputValue value)
    {
        _rb.AddForce(new Vector3(0, _jumpForce, 0));
    }
}
