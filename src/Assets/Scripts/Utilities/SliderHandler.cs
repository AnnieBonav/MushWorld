using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    [SerializeField] private string _selectSoundEvent;
    [SerializeField] private string _navigateSoundEffect;
    [SerializeField] private string _rtcpValueName = "musicVolume";
    [SerializeField] private Slider _slider;

    public void UpdateValue()
    {
        AkSoundEngine.SetRTPCValue(_rtcpValueName, _slider.value * 100);
    }
    public void PlayNavigateSound()
    {
        AkSoundEngine.PostEvent(_navigateSoundEffect, gameObject);
    }

    public void PlaySound()
    {
        AkSoundEngine.PostEvent(_selectSoundEvent, gameObject);
    }
}
