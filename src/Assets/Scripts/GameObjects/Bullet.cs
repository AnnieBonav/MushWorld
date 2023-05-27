using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeToLive = 5;
    [SerializeField] private bool _killOverTime = false;
    [SerializeField] private float _speed = 130;
    [SerializeField] private int _damage = 2;

    private Transform _parentTransform;

    public int Damage
    {
        get { return _damage; }
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

    private void FixedUpdate()
    {
        transform.Translate(_parentTransform.forward * _speed);
        // transform.LookAt(camera.mmain.tramsform.position + Camera.,main,transform.forward)
    }

    private IEnumerator Live()
    {
        yield return new WaitForSeconds(_timeToLive);
        print("I am deactivating");
        Deactivate();
    }
}
