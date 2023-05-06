using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public static event Action<int> CollectedMushroom;
    [SerializeField] private int _points;
    private Vector3 _initialPosition;
    private Transform _transform;
    private Vector3 _movement;
    private float _randomChange;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        StartCoroutine(ChangeDirection());
    }

    private void FixedUpdate()
    {
        _transform.position = new Vector3(_transform.position.x + _randomChange, _transform.position.y, _transform.position.z + _randomChange);
    }

    public int Points
    {
        get { return _points; }
    }

    public Mushroom(int points)
    {
        _points = points;
    }

    public Mushroom(int points, Vector3 initialPosition)
    {
        _initialPosition = initialPosition;
        _initialPosition = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collected Something!: " + other.gameObject.layer);
        if(other.gameObject.layer == 6)
        {
            CollectedMushroom?.Invoke(_points);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator ChangeDirection()
    {
        _randomChange = UnityEngine.Random.Range(-0.1f, 0.1f);
        yield return new WaitForSeconds(5);
    }
}
