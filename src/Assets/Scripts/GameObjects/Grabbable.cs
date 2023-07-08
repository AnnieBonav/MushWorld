using System;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public static event Action<Grabbable> CollectedGrabbable;

    [SerializeField] private string _soundEvent;
    [SerializeField] private GameObject _grabParticle;
    [SerializeField] private bool _getsDestroyed = true;

    public Sprite UISprite; // TODO: Check if public is needed, used so the iNventoryItem can be initialized with the sprite
    private void Awake()
    {
        if (_soundEvent == null)
        {
            print("No sound has been defined. Basic will be called.");
            // TODO: Add basic sound
        }
    }

    public void SetDestroys()
    {
        _getsDestroyed = true;
        AkSoundEngine.PostEvent("Play_PlaceObject", gameObject);
    }

    public virtual void Grab()
    {
        CollectedGrabbable?.Invoke(this);
        PlaySound();
        if (_getsDestroyed)
        {
            Instantiate(_grabParticle, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    protected void PlaySound()
    {
        AkSoundEngine.PostEvent(_soundEvent, gameObject);
    }
}
