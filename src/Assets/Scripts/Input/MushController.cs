using UnityEngine;
using UnityEngine.InputSystem;

public class MushController : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _movement;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_movement * _speed);
    }

    public void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        _movement = new Vector3(inputVector.x, 0, inputVector.y);
        Debug.Log("Input value: " + _movement);
    }

    public void OnLook(InputValue value)
    {

    }

    public void OnJump(InputValue value)
    {
        _rb.AddForce(new Vector3(0, _jumpForce, 0));
    }
}
