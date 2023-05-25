using UnityEngine;
using UnityEngine.InputSystem;

public class MushController : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private float _minHeadRotationY = -60;
    [SerializeField] private float _maxHeadRotationY = 30;
    [SerializeField] private float _sensitivityY = 0.1f;
    private float _headRotationY = 0;

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

        _headRotationY = _head.eulerAngles.x;
    }

    private void RespawnPlayer()
    {
        print("Is respawning");
        _transform.position = _respawnPosition;
        _rb.velocity = new Vector3();
    }

    private void FixedUpdate()
    {
        _transform.Rotate(Vector3.up, _rotation.x * _rotationSensitivity);
        _movement = _transform.TransformDirection(_impulse);
        _rb.AddForce(_movement * _speed);

        AkSoundEngine.SetRTPCValue("speed", _rb.velocity.magnitude);
    }

    public void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        _impulse = new Vector3(inputVector.x, 0, inputVector.y);
    }

    public void OnLook(InputValue value)
    {
        //print("Head rotation: " + _headRotationY + "Min head rotation: " + _minHeadRotationY + " Max head rotation: " + _maxHeadRotationY);
        Vector2 inputVector = value.Get<Vector2>();
        _rotation = new Vector3(inputVector.x, 0, inputVector.y);
        
       // RotateHead(inputVector);
    }

    private void RotateHead(Vector3 inputVector)
    {
        float newPosition = _headRotationY + (inputVector.y * _sensitivityY * Time.deltaTime) * -1;
        if (newPosition >= _minHeadRotationY && newPosition <= _maxHeadRotationY)
        {
            _headRotationY = newPosition;
            print("newPosition: " + newPosition + "Added: " + inputVector.y + " Total: " + _headRotationY);
            _head.rotation = Quaternion.Euler(_headRotationY, 0, 0);
            print("Head rotation x: " + _head.rotation.x);
        }
    }

    public void OnJump(InputValue value)
    {
        _rb.AddForce(new Vector3(0, _jumpForce, 0));
    }
}
