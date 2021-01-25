using UnityEngine;

public enum EnemyType
{
	Fairy,
	Youkai,
	Machine
}

public class EnemyStats : MonoBehaviour
{
	[SerializeField] private EnemyType type = EnemyType.Youkai;
	private                  int       HP   = 10;

	public void TakeDamage(int damage, EnemyType damageType)
	{
		if (damageType == type)
		{
			HP -= damage;
			if (HP <= 0)
			{
				Destroy(gameObject);
			}
		}
		else
		{
			Debug.Log("No damage");
		}
	}
}