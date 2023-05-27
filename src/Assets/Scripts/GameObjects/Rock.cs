using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private int _life = 3;

    private void OnCollisionEnter(Collision collision)
    {
        print("Had a collision with: " + collision.gameObject.name);
        if (collision.transform.CompareTag("Weapon"))
        {
            int damage = collision.transform.GetComponent<Bullet>().Damage;
            print("Collided with something that should hurt. Damage: " + damage  + "  Current life: " + _life);
            GetDamaged(damage);
        }
    }

    private void GetDamaged(int damage)
    {
        _life -= damage;
        CheckStatus();
    }

    private void CheckStatus()
    {
        if(_life <= 0)
        {
            print("I died!");

        }
    }
}
