using TMPro;
using UnityEngine;

public class UpgradeDescription : MonoBehaviour
{
	[SerializeField] private string   statMessage;
	[SerializeField] private string   statMessage2;
	[SerializeField] private string   statMessage3;
	[SerializeField] private TMP_Text levelText;
	[SerializeField] private TMP_Text statText;

	[SerializeField] private TMP_Text coinText;
	[SerializeField] private TMP_Text kappaTokensText;

	[SerializeField] private string statName;

	// public void Start()
	// {
	// 	int currentLevel = 0;
	// 	if (statName is "CharacterHP")
	// 	{
	// 		currentLevel = GameManager.Instance.PlayerCharacter.HPLevel;
	// 	}
	//
	// 	if (statName is "CharacterBarrier")
	// 	{
	// 		currentLevel = GameManager.Instance.PlayerCharacter.BarrierCooldownLevel;
	// 	}
	//
	// 	if (statName is "AmplifiedSpeaker")
	// 	{
	// 		currentLevel = GameManager.Instance.AmplifiedSpeakers.PowerLevel;
	// 	}
	//
	// 	if (statName is "WaterBalloonLauncer")
	// 	{
	// 		currentLevel = GameManager.Instance.WaterBalloonLauncher.PowerLevel;
	// 	}
	//
	// 	if (statName is "StaticBomb")
	// 	{
	// 		currentLevel = GameManager.Instance.StaticBomb.PowerLevel;
	// 	}
	//
	// 	int costInCoins       = 100 * currentLevel;
	// 	int costInKappaTokens = 2   * (currentLevel - 5);
	// 	costInKappaTokens = Mathf.Max(costInKappaTokens, 0);
	//
	// 	coinText.text        = costInCoins.ToString();
	// 	kappaTokensText.text = costInKappaTokens.ToString();
	//
	// 	levelText.text = "Level " + currentLevel;
	// }
	//
	// public bool UpgradeStat(int newValue, int upgradeLevel,
	//                         CurrencyData payment)
	// {
	// 	if (!IsAffordable(upgradeLevel + 1, payment))
	// 	{
	// 		Debug.Log("Not affordable" + payment);
	// 		return false;
	// 	}
	//
	// 	if (upgradeLevel < 10)
	// 	{
	// 		upgradeLevel++;
	// 		levelText.text = "Level " + upgradeLevel;
	// 		statText.text  = string.Format("{0} {1}", statMessage, newValue);
	//
	// 		int costInCoins       = 100 * upgradeLevel;
	// 		int costInKappaTokens = 2   * (upgradeLevel - 5);
	// 		costInKappaTokens = Mathf.Max(costInKappaTokens, 0);
	//
	// 		coinText.text        = costInCoins.ToString();
	// 		kappaTokensText.text = costInKappaTokens.ToString();
	//
	// 		return true;
	// 	}
	//
	// 	return false;
	// }
	//
	// private bool IsAffordable(int currentLevel, CurrencyData payment)
	// {
	// 	int costInCoins       = 100 * currentLevel;
	// 	int costInKappaTokens = 2   * (currentLevel - 5);
	// 	costInKappaTokens = Mathf.Max(costInKappaTokens, 0);
	//
	// 	coinText.text        = (100 * currentLevel).ToString();
	// 	kappaTokensText.text = Mathf.Max(costInKappaTokens, 0).ToString();
	//
	// 	bool isValidPurchase = false;
	//
	// 	float coinAffordabilityRatio      = (float) payment.Coins       / costInCoins;
	// 	float kappaTokenAfforabilityRatio = (float) payment.KappaTokens / costInKappaTokens;
	//
	// 	Debug.Log(payment);
	// 	return coinAffordabilityRatio      >= 1.0f &&
	// 	       kappaTokenAfforabilityRatio >= 1.0f;
	// }
	//
	// public bool UpgradeStat(float newValue, int upgradeLevel, CurrencyData payment)
	// {
	// 	if (!IsAffordable(upgradeLevel + 1, payment))
	// 	{
	// 		Debug.Log("Not affordable" + payment);
	// 		return false;
	// 	}
	//
	// 	if (upgradeLevel < 10)
	// 	{
	// 		upgradeLevel++;
	// 		levelText.text = "Level " + upgradeLevel;
	// 		statText.text  = string.Format("{0} {1:#.00}", statMessage, newValue);
	//
	// 		int costInCoins       = 100 * upgradeLevel;
	// 		int costInKappaTokens = 2   * (upgradeLevel - 5);
	// 		costInKappaTokens = Mathf.Max(costInKappaTokens, 0);
	//
	// 		coinText.text        = costInCoins.ToString();
	// 		kappaTokensText.text = costInKappaTokens.ToString();
	// 		return true;
	// 	}
	//
	// 	return false;
	// }
	//
	// public bool UpgradeStats(int newPower, float CD, int upgradeLevel, float secondaryEffect = 0,
	//                          CurrencyData payment = null)
	// {
	// 	if (payment != null)
	// 	{
	// 		if (!IsAffordable(upgradeLevel + 1, payment))
	// 		{
	// 			Debug.Log("Not affordable" + payment);
	// 			return false;
	// 		}
	// 	}
	//
	// 	if (upgradeLevel < 10)
	// 	{
	// 		upgradeLevel++;
	// 		levelText.text = "Level " + upgradeLevel;
	//
	// 		int costInCoins       = 100 * upgradeLevel;
	// 		int costInKappaTokens = 2   * (upgradeLevel - 5);
	// 		costInKappaTokens = Mathf.Max(costInKappaTokens, 0);
	//
	// 		coinText.text        = costInCoins.ToString();
	// 		kappaTokensText.text = costInKappaTokens.ToString();
	//
	// 		if (secondaryEffect != 0)
	// 		{
	// 			statText.text = string.Format("{0} {1}\n{2} {3:#.00}\n{4} {5:#.00}",
	// 			                              statMessage, newPower, statMessage2, CD, statMessage3, secondaryEffect);
	// 		}
	// 		else
	// 		{
	// 			statText.text = string.Format("{0} {1}\n{2} {3:#.00}", statMessage, newPower, statMessage2, CD);
	// 		}
	//
	// 		return true;
	// 	}
	//
	// 	return false;
	// }
}
