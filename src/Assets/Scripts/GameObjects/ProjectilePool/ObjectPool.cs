using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> _pooledObjects;
    private GameObject _prefabToPool;
    private int _poolSize;

    public ObjectPool(int amountToPool, GameObject prefabToPool)
    {
        _poolSize = amountToPool;
        _prefabToPool = prefabToPool; // Sent through whoever instantiates the Object Pool
        InitializePool();
    }

    private void InitializePool()
    {
        _pooledObjects = new List<T>();
        T temporaryObject;
        for (int i = 0; i < _poolSize; i++)
        {
            temporaryObject = Object.Instantiate(_prefabToPool).GetComponent<T>();
            temporaryObject.gameObject.SetActive(false);
            _pooledObjects.Add(temporaryObject);
        }

    }

    public T GetPooledObject()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            if (!_pooledObjects[i].gameObject.activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return default(T);
    }
}
