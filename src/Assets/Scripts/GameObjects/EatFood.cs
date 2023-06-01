using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EatFood : MonoBehaviour
{
    [SerializeField] private GameObject _foodParent;
    private string _foodName;

    private void Awake()
    {
        _foodName = _foodParent.name;
        EyesVisualizer.ConsumedFood += ConsumeFood; // Suncribs to when on Grab the eyes visualizer touch a food plate
    }
    private void ConsumeFood(string foodName)
    {
        if(_foodName == foodName && _foodParent.transform.childCount > 0)
        {
            Destroy(_foodParent.transform.GetChild(0).gameObject);
        }
    }
    
}
