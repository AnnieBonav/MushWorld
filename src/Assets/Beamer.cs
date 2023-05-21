using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beamer : MonoBehaviour
{
    private Transform _ejectionPoint;
    private WaitForSeconds _shotDuration = new WaitForSeconds(.1f);
    private WaitForSeconds _shotInBetween = new WaitForSeconds(0.5f);
    private LineRenderer _shootingLine;
    private int _beamRange = 50;
    private int _maxBounces = 5;

    private Vector3 _lastEjectionPoint;
    private Vector3 _lastDirection;

    private void Awake()
    {
        _ejectionPoint = transform;
        _shootingLine = GetComponent<LineRenderer>();
        StartCoroutine(Shoot());
    }

    private void SetLinePosition()
    {
        _shootingLine.SetPosition(_shootingLine.positionCount - 1, _lastEjectionPoint);
        _shootingLine.positionCount++;
    }

    private void RaycastWithBounce()
    {
        _shootingLine.positionCount = 1;
        _lastEjectionPoint = _ejectionPoint.position;
        _lastDirection = _ejectionPoint.forward;
        SetLinePosition();

        Ray ray = new Ray(_lastEjectionPoint, _lastDirection);
        RaycastHit hit;

        while (_shootingLine.positionCount < _maxBounces)
        {
            if (Physics.Raycast(ray, out hit, _beamRange))
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
                // _shootingLine.SetPosition(1, _ejectionPoint.forward * _beamRange);
            }
        }
        StartCoroutine(ShotEffect());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            RaycastWithBounce();
            yield return _shotInBetween;
        }
    }

    private IEnumerator ShotEffect()
    {
        _shootingLine.enabled = true;
        yield return _shotDuration;
        _shootingLine.enabled = false;
    }
}
