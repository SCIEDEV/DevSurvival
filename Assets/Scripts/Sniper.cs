using System;
using UnityEngine;

public class Sniper : Enemy
{
    public GameObject projectile;

    public float safeDistance = 8f;

    private void Update()
    {
        var directionalVector = (player.position - transform.position).normalized;

        var targetPosition = player.position - directionalVector * safeDistance;

        agent.SetDestination(targetPosition);

    }
}