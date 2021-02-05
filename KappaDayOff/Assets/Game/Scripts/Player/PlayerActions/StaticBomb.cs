using UnityEngine;
public class StaticBomb : AlliedBullets
{
	public float AoERadius = 5.0f;
	private float stunDuration;
	private void Awake()
	{
		//damage     = GameManager.Instance.StaticBomb.Power;
		//damageType = EnemyType.Machine;
		//type       = BulletType.StaticBomb;
		//stunDuration = GameManager.Instance.StaticBomb.ImmobilizationTime;
	}


	protected override void activateEffect()
	{
		var colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, AoERadius);
		for (int i = 0; i < colliders.Length; i++)
		{
			var enemy = colliders[i].GetComponent<EnemyShooterBehavior>();
			if (enemy != null)
			{
				enemy.Stun(stunDuration);
			}
		}
	}
}