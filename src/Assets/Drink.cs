using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    [SerializeField] private string _soundName;

    private void Awake()
    {
        EyesVisualizer.ConsumedDrink += PlaySound;
    }
    private void PlaySound()
    {
        print("Playing drink sound");
        // TODO: Implement sound
    }
}
