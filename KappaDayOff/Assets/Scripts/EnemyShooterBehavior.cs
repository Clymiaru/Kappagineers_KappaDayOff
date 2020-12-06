using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterBehavior : MonoBehaviour
{
    public GameObject player;
    public BulletPool objectPool;
    public float secondsPerShot = 1.0f;
    private bool isCoolingDown = false;

    private void Update()
    {
        if (!isCoolingDown && player != null)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        isCoolingDown = true;

        GameObject newShot = objectPool.GetEnemyBullet();
        newShot.transform.position = gameObject.transform.position;
        BulletBehavior shotBehavior = newShot.GetComponent<BulletBehavior>();
        if (shotBehavior != null)
        {
            shotBehavior.SetBulletDestination(player.transform.position);
        }
        yield return new WaitForSeconds(secondsPerShot);
        isCoolingDown = false;
    }
}
