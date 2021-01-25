using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	private Slider bar;
	private int    currentHP;
	private int    maxHP;

	private PlayerStats player;

	private void Awake()
	{
		bar    = GetComponent<Slider>();
		player = GameObject.Find("Player").GetComponent<PlayerStats>();
	}

	private void Start()
	{
		maxHP     = GameManager.Instance.PlayerCharacter.MaxHP;
		currentHP = maxHP;

		bar.maxValue = maxHP;
		bar.value    = currentHP;
	}

	private void Update()
	{
		// TODO: Get reference or event from an actual player in the level
		// currentHealth = player.HP;
		// if (maxHP != currentHP)
		// {
		bar.value = player.HP;
		// }
	}
}