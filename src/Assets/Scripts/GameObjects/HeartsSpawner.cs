using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsSpawner : MonoBehaviour
{
    [SerializeField] private int _amountToPool;
    [SerializeField] private GameObject _prefabToPool;

    private ObjectPool<Absorbable> _hearts;

    public ObjectPool<Absorbable> Absorbables
    {
        get { return _hearts; }
    }

    private void Awake()
    {
        _hearts = new ObjectPool<Absorbable>(_amountToPool, _prefabToPool);
    }
}
