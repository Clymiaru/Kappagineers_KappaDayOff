using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberMissile : MonoBehaviour
{
    public BulletPool bulletPool;
    public int damage = 100;
    public void UseBomb()
    {
        List<GameObject> bulletsToBreak = bulletPool.GetEnemyBullets();
        for (int i = 0; i < bulletsToBreak.Count; i++)
        {
            EnemyBullet bullet = bulletsToBreak[i].GetComponent<EnemyBullet>();
            if (bullet != null)
            {
                bullet.TakeDamage(damage);
            }
        }
    }
}
