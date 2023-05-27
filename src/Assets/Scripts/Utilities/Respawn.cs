using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public static event Action NeedRespawn;
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            print("Need respawn");
            NeedRespawn?.Invoke();
        }

        if (collider.CompareTag("Weapon"))
        {
            Bullet tempBullet = collider.gameObject.GetComponent<Bullet>();
            if (tempBullet != null)
            {
                tempBullet.Deactivate();
            }
            
        }
    }
}
