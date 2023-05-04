using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public static event Action<int> CollectedMushroom;
    [SerializeField] private int _points;
    private Vector3 _initialPosition;
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
}
