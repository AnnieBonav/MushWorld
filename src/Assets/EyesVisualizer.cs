using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesVisualizer : MonoBehaviour
{
    private LineRenderer _trail;
    private Vector3 _cameraOrigin = new Vector3(0.5f, 0.5f, 0f);
    [SerializeField] private float _rayLength = 50f;
    [SerializeField] private Transform _origin;

    private void Awake()
    {
        _trail = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ViewportPointToRay(_cameraOrigin);
        RaycastHit hit;
        bool hitSomething = Physics.Raycast(ray, out hit, _rayLength);

        _trail.SetPosition(0, _origin.position);
        _trail.SetPosition(1, hit.point);
    }
}
