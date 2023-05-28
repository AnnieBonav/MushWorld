using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour
{
    [SerializeField] private float _timeToLive = 1f;
    private WaitForSeconds _livingTime;

    private void Awake()
    {
        _livingTime = new WaitForSeconds(_timeToLive);
        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        yield return _livingTime;
        gameObject.SetActive(false);
    }
}
