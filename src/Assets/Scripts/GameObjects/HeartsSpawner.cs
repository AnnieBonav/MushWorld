using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _spaceDimensions;
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
        for(int i = 0; i < _amountToPool; i++)
        {
            Absorbable tempHeart = _hearts.GetPooledObject();
            tempHeart.gameObject.transform.SetParent(gameObject.transform);
            tempHeart.gameObject.transform.position = new Vector3(Random.Range(-_spaceDimensions.x, _spaceDimensions.x), 0, Random.Range(-_spaceDimensions.y, _spaceDimensions.y));
            tempHeart.gameObject.SetActive(true);
        }

        transform.position = new Vector3(transform.position.x + 30, transform.position.y, transform.position.z);
    }
}
