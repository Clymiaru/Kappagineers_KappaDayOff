using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    protected Vector3 destination;
    protected Vector3 flightDirection;
    protected float speed = 0.25f;
    protected int damage = 10;
    protected EnemyType damageType;

    public void SetBulletDestination(Vector3 target)
    {
        destination = target;
        flightDirection = (target - gameObject.transform.position).normalized;
    }

    private void Update()
    {
        gameObject.transform.position += speed * flightDirection;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyStats enemy = collision.gameObject.GetComponent<EnemyStats>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage, damageType);
            Destroy(gameObject);
        }
    }
}
