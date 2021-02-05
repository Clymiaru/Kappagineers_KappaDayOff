using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
	public enum BulletType
	{
		AmplifiedWave,
		StaticBomb,
		WaterBalloon,
		EnemyBullet
	}

	protected int        damage = 10;
	protected Vector3    flightDirection;
	protected BulletPool objectPool;
	protected float      speed = 0.25f;

	protected BulletType type;

	private void Update()
	{
		gameObject.transform.position += speed * flightDirection;
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

	private void OnBecameInvisible()
	{
		gameObject.SetActive(false);
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
}