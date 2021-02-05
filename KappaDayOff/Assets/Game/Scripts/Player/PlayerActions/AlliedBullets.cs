using UnityEngine;

public abstract class AlliedBullets : BulletBehavior
{
	protected EnemyType damageType;

	protected void Awake()
	{
		speed = 0.25f;
		currentSpeed = speed;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		var enemy = collision.gameObject.GetComponent<EnemyStats>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage, damageType);
			activateEffect();
			gameObject.SetActive(false);
		}
		else
		{
			var enemyBullet = collision.gameObject.GetComponent<EnemyBullet>();
			if (enemyBullet != null)
			{
				enemyBullet.TakeDamage(damage);
				activateEffect();
				gameObject.SetActive(false);
			}
		}
	}

	protected abstract void activateEffect();
}