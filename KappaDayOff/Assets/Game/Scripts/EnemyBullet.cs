using UnityEngine;

public class EnemyBullet : BulletBehavior
{
	protected int bulletHP = 10;

	public EnemyBullet()
	{
		speed = 0.05f;
		type  = BulletType.EnemyBullet;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		var player = collision.gameObject.GetComponent<PlayerStats>();
		if (player != null)
		{
			player.TakeDamage(damage);
			gameObject.SetActive(false);
		}
		else
		{
			if (collision.gameObject.tag == "Barrier")
			{
				gameObject.SetActive(false);
			}
		}
	}

	public void TakeDamage(int damage)
	{
		bulletHP -= damage;
		if (bulletHP <= 0)
		{
			gameObject.SetActive(false);
		}
	}
}