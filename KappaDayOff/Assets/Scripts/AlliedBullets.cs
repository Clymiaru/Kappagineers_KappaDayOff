using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliedBullets : BulletBehavior
{
    protected EnemyType damageType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyStats enemy = collision.gameObject.GetComponent<EnemyStats>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage, damageType);
            Destroy(gameObject);
        }
        else
        {
            EnemyBullet enemyBullet = collision.gameObject.GetComponent<EnemyBullet>();
            if (enemyBullet != null)
            {
                enemyBullet.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
