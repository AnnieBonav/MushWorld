using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    [SerializeField] private Transform _controlPoint0, _controlPoint1, _controlPoint2, _controlPoint3;
    [SerializeField] private float _timeFrame = 1;

    private Transform[] _controlPoints;
    private float _timePassed;
    private bool _goForward = true;

    private void Awake()
    {
        _controlPoints = new Transform[] { _controlPoint0, _controlPoint1, _controlPoint2, _controlPoint3 };
        _timePassed = 0f;
    }

    private void Update()
    {
        _timePassed = _goForward ? (_timePassed + Time.deltaTime) : _timePassed - Time.deltaTime;
        if (_goForward)
        {
            _timePassed = Mathf.Min(_timePassed + Time.deltaTime, _timeFrame);
        }
        else
        {
            _timePassed = Mathf.Max(_timePassed - Time.deltaTime, 0);
        }

        if (_timePassed == 0 || _timePassed == _timeFrame) _goForward = !_goForward;
        transform.position = NewPosition(_timePassed / _timeFrame);
    }

    private Vector3 NewPosition(float t)
    {
        Vector3 pos = Mathf.Pow(1 - t, 3) * _controlPoints[0].position +
                      3 * t * Mathf.Pow(1 - t, 2) * _controlPoints[1].position +
                      3 * Mathf.Pow(t, 2) * (1 - t) * _controlPoints[2].position +
                      Mathf.Pow(t, 3) * _controlPoints[3].position;
        return pos;
    }
}
