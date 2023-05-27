using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public static event Action<Grabbable> CollectedGrabbable;
    public void Grab()
    {
        CollectedGrabbable?.Invoke(this);
        Destroy(this.gameObject);
    }
}
