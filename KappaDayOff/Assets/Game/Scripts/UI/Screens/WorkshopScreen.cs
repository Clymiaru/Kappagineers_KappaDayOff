using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO: Finish workshop functionality and the screen
public class WorkshopScreen : MonoBehaviour
{
    [SerializeField] private List<Button> upgradeCategoryButtons = new List<Button>();

    [SerializeField] private GameObject characterUpgradesPanel = null;
    [SerializeField] private GameObject weaponUpgradesPanel = null;

    [SerializeField] private UpgradeDescription playerHP;
    [SerializeField] private UpgradeDescription barrierCD;
    [SerializeField] private UpgradeDescription amplifiedSpeakersUpgrade;
    [SerializeField] private UpgradeDescription waterBalloonUpgrade;
    [SerializeField] private UpgradeDescription staticBombUpgrade;

    [SerializeField] private AudioSource tapSFX     = null;
    [SerializeField] private AudioSource successSFX = null;
    
    private GameObject currentPanelSelected = null;

    public AdsManager adsManager;
    
    private int optionIndex = 0; // For now, auto-select the first option

    private void OnEnable()
    {
        optionIndex = 0;
        upgradeCategoryButtons[optionIndex].Select();
        currentPanelSelected = characterUpgradesPanel;
        OnCharacterUpgradesSelect();
    }

    private void Update()
    {
        upgradeCategoryButtons[optionIndex].Select();
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnExitScreen();
        }
    }

    public void OnCharacterUpgradesSelect()
    {
        AudioHandler.Instance.PlaySFX(tapSFX);
        
        currentPanelSelected.SetActive(false);
        currentPanelSelected = characterUpgradesPanel.gameObject;
        currentPanelSelected.SetActive(true);
        optionIndex = 0;
    }

    public void OnWeaponUpgradesSelect()
    {
        AudioHandler.Instance.PlaySFX(tapSFX);
        
        currentPanelSelected.SetActive(false);
        currentPanelSelected = weaponUpgradesPanel.gameObject;
        currentPanelSelected.SetActive(true);
        optionIndex = 1;
    }

    public void OnExitScreen()
    {
        AudioHandler.Instance.PlaySFX(tapSFX);
        gameObject.SetActive(false);
        adsManager.HideBannerAd();
    }

    private void UpdateCurrency(int currentLevel)
    {
        int costInCoins       = 100 * currentLevel;
        int costInKappaTokens = 2 * (currentLevel - 5);
        costInKappaTokens = Mathf.Max(costInKappaTokens, 0);

        GameManager.Instance.PlayerCurrency.Coins -= costInCoins;
        GameManager.Instance.PlayerCurrency.KappaTokens -= costInKappaTokens;
    }

    public void OnMaxHPUpgrade()
    {
        int HP    = GameManager.Instance.PlayerCharacter.MaxHP + 50;
        int level = GameManager.Instance.PlayerCharacter.HPLevel;
        
        if(playerHP.UpgradeStat(HP, level, 
                                GameManager.Instance.PlayerCurrency))
        {
            AudioHandler.Instance.PlaySFX(successSFX);
            
            UpgradableStats.Instance().SetPlayerHP(HP);
            UpgradableStats.Instance().upgradePlayerHP();
            
            GameManager.Instance.PlayerCharacter.MaxHP   = HP;
            GameManager.Instance.PlayerCharacter.HPLevel = level + 1;

            UpdateCurrency(level);
        }
    }
    
    public void OnBarrierCooldownUpgrade()
    {
        // if can afford
        // proceed
        // Play success
        // else
        // don't
        
        int   level = GameManager.Instance.PlayerCharacter.BarrierCooldownLevel;
        float CD = 63 - Mathf.Ceil(2.8f * level); //CD formula

        if (barrierCD.UpgradeStat(CD, level,
                                          GameManager.Instance.PlayerCurrency))
        {
            UpgradableStats.Instance().upgradeBarrierCD();
            GameManager.Instance.PlayerCharacter.BarrierCooldownLevel++;

            UpgradableStats.Instance().SetBarrierCD(CD);
            GameManager.Instance.PlayerCharacter.BarrierCooldownTime = CD;

            UpdateCurrency(level);

            AudioHandler.Instance.PlaySFX(successSFX);
        }
    }
    
    public void OnAmplifiedSpeakersUpgrade()
    {
        // if can afford
        // proceed
        // Play success
        // else
        // don't
        
        int   power     = GameManager.Instance.AmplifiedSpeakers.Power        + 5;
        float CD        = GameManager.Instance.AmplifiedSpeakers.CooldownTime - 0.1f;
        int   level     = GameManager.Instance.AmplifiedSpeakers.PowerLevel;
        float knockback = GameManager.Instance.AmplifiedSpeakers.PushDistance + 0.25f * Mathf.Pow(2, Mathf.FloorToInt((level - 1) / 4));//knockback formula

        if (amplifiedSpeakersUpgrade.UpgradeStats(power, CD, level, knockback, 
                                                  GameManager.Instance.PlayerCurrency))
        {
            AudioHandler.Instance.PlaySFX(successSFX);

            GameManager.Instance.AmplifiedSpeakers.PowerLevel++;
            GameManager.Instance.AmplifiedSpeakers.CooldownLevel++;
            GameManager.Instance.AmplifiedSpeakers.PushDistanceLevel++;

            GameManager.Instance.AmplifiedSpeakers.Power        = power;
            GameManager.Instance.AmplifiedSpeakers.CooldownTime = CD;
            GameManager.Instance.AmplifiedSpeakers.PushDistance = knockback;
            
            UpdateCurrency(level);
            
            UpgradableStats.Instance().upgradeAmplifiedSpeakers();
            UpgradableStats.Instance().SetSpeakerPower(power);
            UpgradableStats.Instance().SetSpeakerCD(CD);
            UpgradableStats.Instance().SetSpeakerPushDistance(knockback);
        }
    }
    
    public void OnWaterBalloonLauncherUpgrade()
    {
        // if can afford
        // proceed
        // Play success
        // else
        // don't
        
        int   power = GameManager.Instance.WaterBalloonLauncher.Power        + 5;
        float CD    = GameManager.Instance.WaterBalloonLauncher.CooldownTime - 0.1f;
        int   level = GameManager.Instance.WaterBalloonLauncher.PowerLevel;
        if (waterBalloonUpgrade.UpgradeStats(power, CD, level, 0, 
                                             GameManager.Instance.PlayerCurrency))
        {
            AudioHandler.Instance.PlaySFX(successSFX);
            
            GameManager.Instance.WaterBalloonLauncher.PowerLevel++;
            GameManager.Instance.WaterBalloonLauncher.CooldownLevel++;

            GameManager.Instance.WaterBalloonLauncher.Power        = power;
            GameManager.Instance.WaterBalloonLauncher.CooldownTime = CD;
            
            UpdateCurrency(level);
            
            UpgradableStats.Instance().upgradeWaterBalloon();
            UpgradableStats.Instance().SetWaterBalloonPower(power);
            UpgradableStats.Instance().SetWaterBalloonCD(CD);
        }
    }
    
    public void OnStaticBombUpgrade()
    {
        // if can afford
        // proceed
        // Play success
        // else
        // don't
        
        int power = UpgradableStats.Instance().GetStaticBombPower() + 5;
        float CD = UpgradableStats.Instance().GetStaticBombCD() - 0.1f;
        int level = UpgradableStats.Instance().GetStaticBombLevel();
        float stunDuration = UpgradableStats.Instance().GetStaticBombDuration() + 0.05f * Mathf.Pow(2, Mathf.FloorToInt((level - 1) / 3));

        if (staticBombUpgrade.UpgradeStats(power, CD, level, stunDuration, 
                                           GameManager.Instance.PlayerCurrency))
        {
            AudioHandler.Instance.PlaySFX(successSFX);
            
            GameManager.Instance.StaticBomb.PowerLevel++;
            GameManager.Instance.StaticBomb.CooldownLevel++;
            GameManager.Instance.StaticBomb.ImmobilizationTimeLevel++;

            GameManager.Instance.StaticBomb.Power              = power;
            GameManager.Instance.StaticBomb.CooldownTime       = CD;
            GameManager.Instance.StaticBomb.ImmobilizationTime = stunDuration;
            
            UpdateCurrency(level);
            
            UpgradableStats.Instance().upgradeStaticBomb();
            UpgradableStats.Instance().SetStaticBombPower(power);
            UpgradableStats.Instance().SetStaticBombCD(CD);
            UpgradableStats.Instance().SetStaticBombDuration(stunDuration);
        }
    }
}
