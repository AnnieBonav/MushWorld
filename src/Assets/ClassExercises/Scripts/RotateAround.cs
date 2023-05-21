using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _anglesPerSecond;

    private void FixedUpdate()
    {
        transform.RotateAround(_target.position, Vector3.up, _anglesPerSecond);
    }
}
