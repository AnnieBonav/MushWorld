using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int _amountToPool;
    [SerializeField] private GameObject _prefabToPool;
    private ObjectPool<Bullet> _bullets;

    public ObjectPool<Bullet> Bullets
    {
        get { return _bullets; }
    }

    private void Awake()
    {
        _bullets = new ObjectPool<Bullet>(_amountToPool, _prefabToPool);
    }
}
