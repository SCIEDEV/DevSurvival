using System;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public int faction = 0;
    
    public float maxHealth = 100;
    public float health = 100;

    private void Start()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        
    }
}