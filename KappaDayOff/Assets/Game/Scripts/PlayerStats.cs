using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public int HP = 50;

	private void Start()
	{
		HP = GameManager.Instance.PlayerCharacter.MaxHP;
	}

	public void TakeDamage(int damage)
	{
		HP -= damage;
		if (HP <= 0)
		{
			Destroy(gameObject);
			SceneLoader.Instance.LoadScene(SceneNames.MainMenu);
		}
	}
}