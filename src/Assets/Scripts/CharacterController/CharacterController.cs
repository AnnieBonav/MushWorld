using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _lookSensitivity = 8f;
    [SerializeField] private float _moveSensitivity = 1; // TODO: Make slider
    [SerializeField] private float _moveSpeed = 40;
    [SerializeField] private float _jumpForce = 200;

    private Rigidbody _rb;
    private Transform _transform;
    private Vector3 _impulse;
    private Vector3 _movement;
    private Vector3 _rotation;

    private Vector3 _respawnPosition;

    private WaitForSeconds _waitStep = new WaitForSeconds(0.5f);
    [SerializeField] private string _footstepsEvent = "Play_Footsteps";

    [SerializeField] private Vector3 _initialPositionRoom = new Vector3(18, 22.4f, -66);
    [SerializeField] private Vector3 _initialPositionWorld = new Vector3(-300, -284, 0);

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _respawnPosition = transform.position;
        Respawn.NeedRespawn += HandleRespawn;
        StartCoroutine(WalkSound());

        SceneManager.activeSceneChanged += PlaceCharacter;
    }

    private void PlaceCharacter(Scene currentScene, Scene nextScene)
    {
        if(nextScene.name == "MainScene")
        {
            transform.position = _initialPositionWorld;
            AkSoundEngine.SetState("music", "chill");
        }
        else if(nextScene.name == "Room")
        {
            transform.position = _initialPositionRoom;
            AkSoundEngine.SetState("music", "dark");
        }

    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator WalkSound()
    {
        while(true)
        {
            yield return _waitStep;
            if (_rb.velocity.magnitude > 0.1)
            {
                AkSoundEngine.PostEvent(_footstepsEvent, gameObject);
            }
        }
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
        _rb.AddForce(_movement * _moveSpeed * _moveSensitivity);
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
