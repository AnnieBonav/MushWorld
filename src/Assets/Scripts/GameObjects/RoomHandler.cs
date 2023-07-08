using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pot;

    private void HandlePotSound(bool isPlaying)
    {
        if(isPlaying)
        {
            AkSoundEngine.PostEvent("Play_Bubbles", _pot);
        }
        else
        {
            AkSoundEngine.PostEvent("Stop_Bubbles", _pot);
        }
    }

    private void OnEnable() // Called every time scene is loaded
    {
        HandlePotSound(true);
        AkSoundEngine.SetSwitch("Footsteps", "Dirt", gameObject);
    }

    private void OnDisable()
    {
        HandlePotSound(false);
        AkSoundEngine.SetSwitch("Footsteps", "Grass", gameObject);
    }
}
