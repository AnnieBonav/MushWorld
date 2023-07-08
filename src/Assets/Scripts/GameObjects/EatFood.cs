using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EatFood : Grabbable
{
    [SerializeField] private GameObject _foodParent;

    public override void Grab()
    {
        PlaySound();
        Destroy(_foodParent.transform.GetChild(0).gameObject);
    }
    
}
