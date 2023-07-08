using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileGun : Weapon
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Transform _ejectionPoint;

    // private WaitForSeconds _shotDuration = new WaitForSeconds(1f); TODO: Add that you cannot shoot at certain moments?

    protected override void Shoot()
    {
        base.Shoot();
        EjectProjectile();
    }

    private void EjectProjectile()
    {
        Bullet bullet = _bulletPool.Bullets.GetPooledObject();
        if (bullet != null)
        {
            bullet.Activate(_ejectionPoint);
            return;
        }
        print("There are no bullets left");
    }
}
