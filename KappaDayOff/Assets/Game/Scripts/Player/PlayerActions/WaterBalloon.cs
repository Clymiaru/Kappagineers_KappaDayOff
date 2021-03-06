﻿using UnityEngine;

public class WaterBalloon : AlliedBullets
{
	public float AoERadius = 5.0f;
	public int   AoEDamage = 5;

	private void Awake()
	{
		base.Awake();
		// damage     = GameManager.Instance.WaterBalloonLauncher.Power;
		// AoEDamage  = damage;
		// damageType = EnemyType.Youkai;
		// type       = BulletType.WaterBalloon;
	}

	protected override void activateEffect()
	{
		var colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, AoERadius);
		for (int i = 0; i < colliders.Length; i++)
		{
			var enemy = colliders[i].GetComponent<EnemyStats>();
			if (enemy != null)
			{
				enemy.TakeDamage(AoEDamage, EnemyType.Youkai);
			}
		}
	}
}
