using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public static event Action NeedRespawn;
    private void OnTriggerExit(Collider other)
    {
        print("Need respawn");
        NeedRespawn?.Invoke();
    }
}
