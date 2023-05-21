using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private Vector3 _rotationSpeed;

    private void FixedUpdate()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        transform.Rotate(_rotationSpeed.x, _rotationSpeed.y, _rotationSpeed.z);
        //transform.localRotation = Quaternion.LookRotation(transform.localRotation);
    }
}
