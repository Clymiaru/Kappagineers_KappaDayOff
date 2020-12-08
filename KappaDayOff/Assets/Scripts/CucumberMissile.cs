using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberMissile : MonoBehaviour, ISwipped
{
    public BulletPool bulletPool;
    public int damage = 100;
    public GameObject barrier;

    public void OnSwipe(SwipeEventArgs args)
    {
        if (!barrier.activeSelf)
        {
            List<GameObject> enemyBullets = bulletPool.GetEnemyBullets();
            List<GameObject> bulletsToBreak = new List<GameObject>();

            for (int i = 0; i < enemyBullets.Count; i++)
            {
                if (args.SwipeDirection == SwipeDirections.RIGHT)
                {
                    if (Camera.main.WorldToScreenPoint(enemyBullets[i].transform.position).x > Screen.width / 2)
                    {
                        bulletsToBreak.Add(enemyBullets[i]);
                    }
                }
                else if (args.SwipeDirection == SwipeDirections.LEFT)
                {
                    if (Camera.main.WorldToScreenPoint(enemyBullets[i].transform.position).x < Screen.width / 2)
                    {
                        bulletsToBreak.Add(enemyBullets[i]);
                    }
                }
            }

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
}
