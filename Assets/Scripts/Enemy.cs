using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : BaseHealth
{
    public NavMeshAgent agent;
    public Transform player;

    public GameObject explosion;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        
        transform.localScale *= 0.7f + 0.3f * (health / 20f);
    }

    public override void Death()
    {
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        Destroy(gameObject);
    }
}
