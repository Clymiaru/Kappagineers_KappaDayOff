using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
	public enum BulletType
	{
		AmplifiedWave,
		StaticBomb,
		WaterBalloon,
		EnemyBullet,
		Boss2Bullet
	}

	protected int        damage = 10;
	protected Vector3    flightDirection;
	protected BulletPool objectPool;
	protected float      speed = 0.25f;
	protected float		 acceleration = 0;

	protected BulletType type;

	protected void Update()
	{
		gameObject.transform.position += speed * flightDirection;
		speed += acceleration * Time.deltaTime;
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
			case BulletType.Boss2Bullet:
				objectPool.ReturnBoss2Bullet(gameObject);
				break;
		}
	}

	private void OnBecameInvisible()
	{
		gameObject.SetActive(false);
		speed = 0.25f;
		acceleration = 0;
	}

	public void SetBulletDestination(Vector3 target)
	{
		flightDirection = (target - gameObject.transform.position).normalized;
	}

	public void SetBulletSpeed(float speed)
    {
		this.speed = speed;
    }

	public void SetBulletPool(BulletPool pool)
	{
		objectPool = pool;
	}

	public void setAcceleration(float accel)
    {
		acceleration = accel;
    }
}