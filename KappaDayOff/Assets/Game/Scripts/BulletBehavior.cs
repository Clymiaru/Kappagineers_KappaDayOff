using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    protected Vector3 flightDirection;
    protected float speed = 0.25f;
    protected int damage = 10;
    protected BulletPool objectPool;

    public enum BulletType
    {
        AmplifiedWave, StaticBomb, WaterBalloon, EnemyBullet
    }

    protected BulletType type;

    public void SetBulletDestination(Vector3 target)
    {
        flightDirection = (target - gameObject.transform.position).normalized;
    }

    public void SetBulletPool(BulletPool pool)
    {
        objectPool = pool;
    }

    private void Update()
    {
        gameObject.transform.position += speed * flightDirection;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        switch (type)
        {
            case BulletType.AmplifiedWave:
                objectPool.ReturnAmplifiedWaves(gameObject);
                break;
            case BulletType.StaticBomb:
                objectPool.ReturnStaticBomb(gameObject);
                break;
            case BulletType.WaterBalloon:
                objectPool.ReturnWaterBalloon(gameObject);
                break;
            case BulletType.EnemyBullet:
                objectPool.ReturnEnemyBullet(gameObject);
                break;
        }
    }
}
