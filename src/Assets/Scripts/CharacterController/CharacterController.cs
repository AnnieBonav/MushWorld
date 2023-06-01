using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _lookSensitivity = 8f;
    [SerializeField] private float _moveSensitivity = 1;
    [SerializeField] private float _moveSpeed = 40;
    [SerializeField] private float _jumpForce = 200;
    [SerializeField] private bool _grabDebug = false;

    private Rigidbody _rb;
    private Transform _transform;
    private Vector3 _impulse;
    private Vector3 _movement;
    private Vector3 _rotation;

    private Vector3 _respawnPosition;

    [SerializeField] private float _rayLength = 50f;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _respawnPosition = transform.position;
        Respawn.NeedRespawn += HandleRespawn;
    }

    private void FixedUpdate()
    {
        _transform.Rotate(Vector3.up, _rotation.x * _lookSensitivity);
        HandleMove();
    }

    private void HandleRespawn()
    {
        _transform.position = _respawnPosition;
        _rb.velocity = new Vector3();
    }

    private void HandleMove()
    {
        _movement = _transform.TransformDirection(_impulse);
        _rb.AddForce(_movement * _moveSpeed);
    }

    public void OnLookHorizontal(InputValue value)
    {
        float horizontalInput = value.Get<float>();
        _rotation = new Vector3(horizontalInput, 0, horizontalInput);
    }

    public void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        _impulse = new Vector3(inputVector.x, 0, inputVector.y);
    }

    public void OnJump(InputValue value)
    {
        _rb.AddForce(new Vector3(0, _jumpForce, 0));
    }
}
