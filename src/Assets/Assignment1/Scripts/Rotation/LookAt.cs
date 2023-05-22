using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform _lookTarget;
    private void FixedUpdate()
    {
        transform.LookAt(_lookTarget, Vector3.up);
    }
}
