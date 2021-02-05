using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Bullet : EnemyBullet
{
    private float secondsPerShot = 2f;
    private bool isCoolingDown;
    private int bulletsPerSide = 2;

    public Boss2Bullet()
    {
        speed = 0.05f;
        type = BulletType.Boss2Bullet;
    }

    private void Update()
    {
        base.Update();

        if (!isCoolingDown)
        {
            StartCoroutine(Shoot());
        }
    }

	private IEnumerator Shoot()
	{
		isCoolingDown = true;

        for(int i = 0; i < bulletsPerSide; i++)
        {
            GameObject newShot = objectPool.GetEnemyBullet();
            newShot.transform.position = gameObject.transform.position;
            var shotBehavior = newShot.GetComponent<BulletBehavior>();
            if (shotBehavior != null)
            {
                shotBehavior.SetBulletDestination(gameObject.transform.position + Vector3.left);
            }
        }

        for (int i = 0; i < bulletsPerSide; i++)
        {
            GameObject newShot = objectPool.GetEnemyBullet();
            newShot.transform.position = gameObject.transform.position;
            var shotBehavior = newShot.GetComponent<BulletBehavior>();
            if (shotBehavior != null)
            {
                shotBehavior.SetBulletDestination(gameObject.transform.position + Vector3.up);
            }
        }

        yield return new WaitForSeconds(secondsPerShot);
		isCoolingDown = false;
	}
}
