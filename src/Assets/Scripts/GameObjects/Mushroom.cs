using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public static event Action<int> CollectedMushroom;

    [SerializeField] private int _points;

    private void Awake()
    {
    }

    public int Points
    {
        get { return _points; }
    }

    public Mushroom(int points)
    {
        _points = points;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 6)
        {
            CollectedMushroom?.Invoke(_points);
            gameObject.SetActive(false);
        }
    }
}
