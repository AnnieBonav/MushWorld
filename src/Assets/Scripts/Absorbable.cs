using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorbable : MonoBehaviour
{
    public static event Action AbsorbedHeart;
    [SerializeField] private GameObject _absorbParticle;
    [SerializeField] private string _soundEvent;

    

    private void Awake()
    {
        if (_soundEvent == null)
        {
            print("No sound has been defined. Basic will be called.");
            // TODO: Add basic sound
        }
    }

    

    private void FixedUpdate()
    {
        // Implement moving
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            print("Absorbed by player");
            AkSoundEngine.PostEvent(_soundEvent, gameObject);
            Instantiate(_absorbParticle, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            AbsorbedHeart?.Invoke();
            Destroy(gameObject);
        }
    }
}
