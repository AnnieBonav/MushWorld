using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : Weapon
{
    [SerializeField] private Transform _ejectionPoint;
    [SerializeField] private int _weaponRange = 50;
    [SerializeField] private bool _isReflecting = false;
    [SerializeField] private int _maxBounces = 5;

    private WaitForSeconds _shotDuration = new WaitForSeconds(1f);
    private LineRenderer _shootingLine;

    private Vector3 _lastEjectionPoint;
    private Vector3 _lastDirection;

    private void Awake()
    {
        _shootingLine = GetComponent<LineRenderer>();
    }

    protected override void Shoot()
    {
        print("Shooting in lazer gun.");
        if (_isReflecting) ShowBouncingRaycats();
        else ShowRaycast();
    }

    private void SetLinePosition()
    {
        _shootingLine.SetPosition(_shootingLine.positionCount - 1, _lastEjectionPoint);
        _shootingLine.positionCount++;
    }

    private void ShowBouncingRaycats()
    {
        _shootingLine.positionCount = 1;
        _lastEjectionPoint = _ejectionPoint.position;
        _lastDirection = _ejectionPoint.forward;
        SetLinePosition();

        Ray ray = new Ray(_lastEjectionPoint, _lastDirection);
        RaycastHit hit;

        while (_shootingLine.positionCount < _maxBounces)
        {
            if (Physics.Raycast(ray, out hit, _weaponRange))
            {
                _lastEjectionPoint = hit.point; // set new origin, where it hit
                SetLinePosition();

                // Update new values
                _lastDirection = Vector3.Reflect(ray.direction, hit.normal);
                ray = new Ray(_lastEjectionPoint, _lastDirection);
            }
            // Did not shoot
            else
            {
                print("Is breaking");
                break;
                // _shootingLine.SetPosition(1, _ejectionPoint.forward * _weaponRange);
            }
        }
        StartCoroutine(ShotEffect());
    }

    private void ShowRaycast()
    {
        _shootingLine.SetPosition(0, _ejectionPoint.position);
        RaycastHit hit;


        if (Physics.Raycast(_ejectionPoint.position, _ejectionPoint.forward, out hit, _weaponRange)) _shootingLine.SetPosition(1, hit.point);
        else _shootingLine.SetPosition(1, _ejectionPoint.forward * _weaponRange);

        StartCoroutine(ShotEffect());
    }

    private IEnumerator ShotEffect()
    {
        _shootingLine.enabled = true;
        yield return _shotDuration;
        _shootingLine.enabled = false;
    }
}
