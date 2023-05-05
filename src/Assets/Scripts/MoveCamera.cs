using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _offsetHorizontal;
    [SerializeField] private float _offsetY;
    private Transform _targetTransform;
    private MushController _characterController;
    private Transform _cameraTransform;
    private void Awake()
    {
        _characterController = _target.GetComponent<MushController>();
        _targetTransform = _target.GetComponent<Transform>();
        _cameraTransform = gameObject.GetComponent<Transform>();
        _cameraTransform.position += new Vector3(0, _offsetY, 0);
    }

    private void FixedUpdate()
    {
        Vector3 targetTransformDirection = _characterController.Movement;
        Vector3 offset = new Vector3(_offsetHorizontal, _offsetY, _offsetHorizontal);
        _cameraTransform.position = _targetTransform.position - Vector3.Scale(_targetTransform.forward, offset) + new Vector3(0, _offsetY, 0);
        _cameraTransform.LookAt(_targetTransform, Vector3.up);
    }

}
