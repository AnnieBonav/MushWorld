using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : Grabbable
{
    public override void Grab()
    {
        print("Grabbed drink");
    }
}
