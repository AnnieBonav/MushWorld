using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public static event Action<Grabbable> CollectedGrabbable;
    [SerializeField] private string _soundEvent;

    private void Awake()
    {
        if(_soundEvent == null)
        {
            print("No sound has been defined. Basic will be called.");
            // TODO: Add basic sound
        }
    }
    public virtual void Grab()
    {
        CollectedGrabbable?.Invoke(this);
        AkSoundEngine.PostEvent(_soundEvent, gameObject);
        Destroy(this.gameObject);
    }
}
