using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBalloon : AlliedBullets
{
    public float AoERadius = 5.0f;
    public int AoEDamage = 5;
    public WaterBalloon()
    {
        damage = UpgradableStats.Instance().GetWaterBalloonPower();
        AoEDamage = damage;
        damageType = EnemyType.Youkai;
        type = BulletType.WaterBalloon;
    }

    protected override void activateEffect()
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
