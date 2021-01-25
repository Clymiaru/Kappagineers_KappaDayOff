public class StaticBomb : AlliedBullets
{
	private void Awake()
	{
		damage     = GameManager.Instance.StaticBomb.Power;
		damageType = EnemyType.Machine;
		type       = BulletType.StaticBomb;
	}


	protected override void activateEffect()
	{
	}
}