using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundParent : MonoBehaviour
{
    [SerializeField] private float _degreesPerSecond;
    [SerializeField] private bool _rotateSlantly = false;
    [SerializeField] private float _radius = 5f;
    
    private float _angle = 0;
    private Vector3 _slantDirection;
    private Transform _parent;

    private void Awake()
    {
        _parent = transform.parent.transform;
        _slantDirection = (transform.position - _parent.position).normalized;
    }

    private void FixedUpdate()
    {
        if (_rotateSlantly)
        {
            OrbitSlantly();
            return;
        }

        Orbit();
    }

    private void Orbit()
    {
        transform.RotateAround(_parent.position, Vector3.up, _degreesPerSecond);
    }

    private void OrbitSlantly()
    {
        _angle += _degreesPerSecond;
        _angle %= 360;

        Vector3 orbit = Vector3.forward * _radius;
        orbit = Quaternion.LookRotation(_slantDirection) * Quaternion.Euler(0, _angle, 0) * orbit;
        transform.position = _parent.position + orbit;
    }
}
