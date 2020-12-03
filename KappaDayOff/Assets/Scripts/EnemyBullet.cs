using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BulletBehavior
{
    protected int bulletHP = 10;
    public EnemyBullet()
    {
        speed = 0.05f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        bulletHP -= damage;
        if (bulletHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
