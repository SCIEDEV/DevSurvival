using UnityEngine;

public class SuicideBomber : Enemy
{
    public float suicideDamage;
    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponent<BaseHealth>();
        if (health != null && health.faction != faction)
        {
            health.TakeDamage(suicideDamage);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        agent.SetDestination(player.position);
    }
}