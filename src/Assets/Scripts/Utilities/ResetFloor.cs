using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFloor : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Switch _footSwitch;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AkSoundEngine.SetSwitch("Footsteps", "Dirt", gameObject);
        }
    }
}
