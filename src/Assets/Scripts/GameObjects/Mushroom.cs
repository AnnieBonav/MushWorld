using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public static event Action<int> CollectedMushroom;

    [SerializeField] private int _points;
    [SerializeField] private float _speed = 5f;

    private Vector2 _randomDirection;
    private Rigidbody _rb;

    private void Awake()
    {
        if(_speed == 0) _speed = 4;
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(ChangeDirectionCoroutine());
    }

    private void FixedUpdate()
    {
        Vector3 newImpulse = new Vector3(_randomDirection.x, 0, _randomDirection.y);
        _rb.AddForce(newImpulse * _speed);
    }

    public int Points
    {
        get { return _points; }
    }

    public Mushroom(int points)
    {
        _points = points;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 6)
        {
            CollectedMushroom?.Invoke(_points);
            gameObject.SetActive(false);
        }else if(other.gameObject.layer == 7)
        {
            ChangeDirection();
        }
    }

    private IEnumerator ChangeDirectionCoroutine()
    {
        ChangeDirection();
        _randomDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        yield return new WaitForSeconds(5);
    }

    private void ChangeDirection()
    {
        _randomDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
    }
}
