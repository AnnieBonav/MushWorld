using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeToLive = 5;
    [SerializeField] private float _speed = 130;
    [SerializeField] private int _damage = 2;

    private Transform _parentTransform;

    public int Damage
    {
        get { return _damage; }
    }
    private void FixedUpdate()
    {
        transform.Translate(_parentTransform.forward * _speed);
    }

    public void Activate(Transform parentTransform)
    {
        gameObject.SetActive(true);
        StartCoroutine(Live());
        _parentTransform = parentTransform;
        gameObject.transform.position = parentTransform.position;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator Live()
    {
        yield return new WaitForSeconds(_timeToLive);
        Deactivate();
    }
}
