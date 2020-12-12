using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmplifiedSpeakers : AlliedBullets
{
    public float AoERadius = 5.0f;
    public int AoEDamage = 5;
    public float knockbackDistance = 2.0f;
    public AmplifiedSpeakers()
    {
        damageType = EnemyType.Fairy;
        type = BulletType.AmplifiedWave;
    }

    protected override void activateEffect()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, AoERadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            EnemyStats enemy = colliders[i].GetComponent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(AoEDamage, EnemyType.Fairy);
                Vector2 direction = Vector2.ClampMagnitude(enemy.gameObject.transform.position - gameObject.transform.position, 1.0f);
                enemy.gameObject.transform.Translate(direction * knockbackDistance);
            }
        }
    }
}
