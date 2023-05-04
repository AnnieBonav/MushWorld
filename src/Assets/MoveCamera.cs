using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private Transform _targetTransform;
    private Transform _cameraTransform;
    private void Awake()
    {
        _targetTransform = _target.GetComponent<Transform>();
        _cameraTransform = gameObject.GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _cameraTransform.LookAt(_targetTransform, Vector3.up);
        
    }

}
