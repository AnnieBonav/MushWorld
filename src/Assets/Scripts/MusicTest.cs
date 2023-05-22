using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Triggered");
        AkSoundEngine.PostEvent("Play_finish", gameObject);
        AkSoundEngine.SetState("music", "finish");
    }
}
