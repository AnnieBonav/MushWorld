using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class River : MonoBehaviour
{
    [SerializeField] private string _soundEvent;

    private void Start()
    {
        PlaySound();
    }

    private void PlaySound()
    {
        AkSoundEngine.PostEvent(_soundEvent, gameObject);
    }
}
