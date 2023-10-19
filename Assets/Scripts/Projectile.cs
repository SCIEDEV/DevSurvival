using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int faction;

    public float damage;
    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponent<BaseHealth>();
        if (health != null && health.faction != faction)
        {
            health.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
