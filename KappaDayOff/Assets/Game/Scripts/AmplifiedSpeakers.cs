using UnityEngine;

public class AmplifiedSpeakers : AlliedBullets
{
	public float AoERadius         = 5.0f;
	public int   AoEDamage         = 5;
	public float knockbackDistance = 2.0f;

	private void Awake()
	{
		damage            = GameManager.Instance.AmplifiedSpeakers.Power;
		knockbackDistance = GameManager.Instance.AmplifiedSpeakers.PushDistance;
		damageType        = EnemyType.Fairy;
		type              = BulletType.AmplifiedWave;
	}


	protected override void activateEffect()
	{
		var colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, AoERadius);
		for (int i = 0; i < colliders.Length; i++)
		{
			var enemy = colliders[i].GetComponent<EnemyStats>();
			if (enemy != null)
			{
				enemy.TakeDamage(AoEDamage, EnemyType.Fairy);
				Vector2 direction = Vector2.ClampMagnitude(enemy.gameObject.transform.position - gameObject.transform.position, 1.0f);
				enemy.gameObject.transform.Translate(direction * knockbackDistance);
			}
		}
	}
}