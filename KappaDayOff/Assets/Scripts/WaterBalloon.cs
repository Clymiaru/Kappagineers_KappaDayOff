using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBalloon : BulletBehavior
{
    public float AoERadius = 5.0f;
    public int AoEDamage = 5;
    public WaterBalloon()
    {
        damageType = EnemyType.Youkai;
    }

    private void OnDestroy()
    {
        ActivateAoE();
    }

    private void ActivateAoE()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, AoERadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            EnemyStats enemy = colliders[i].GetComponent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(AoEDamage, EnemyType.Youkai);
            }
        }
    }
}
