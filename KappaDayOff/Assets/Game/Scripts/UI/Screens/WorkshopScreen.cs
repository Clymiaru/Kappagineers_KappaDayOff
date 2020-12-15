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
    }

    private void UpdateCurrency(int currentLevel)
    {
        int costInCoins       = 100 * currentLevel;
        int costInKappaTokens = (2 * (currentLevel - 5));
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
        
        float CD    = GameManager.Instance.PlayerCharacter.BarrierCooldownTime;
        int   level = GameManager.Instance.PlayerCharacter.BarrierCooldownLevel;
        
        switch (CD)
        {
            case 60:
                if (barrierCD.UpgradeStat(57, level, 
                                          GameManager.Instance.PlayerCurrency))
                {
                    UpgradableStats.Instance().upgradeBarrierCD();
                    GameManager.Instance.PlayerCharacter.BarrierCooldownLevel++;
                    
                    UpgradableStats.Instance().SetBarrierCD(57);
                    GameManager.Instance.PlayerCharacter.BarrierCooldownTime = 57;
                    
                    UpdateCurrency(level);
                    
                    AudioHandler.Instance.PlaySFX(successSFX);
                }
                break;
            case 57:
                if (barrierCD.UpgradeStat(54, level, 
                                          GameManager.Instance.PlayerCurrency))
                {
                    UpgradableStats.Instance().upgradeBarrierCD();
                    GameManager.Instance.PlayerCharacter.BarrierCooldownLevel++;
                    
                    UpgradableStats.Instance().SetBarrierCD(54);
                    GameManager.Instance.PlayerCharacter.BarrierCooldownTime = 54;
                    
                    UpdateCurrency(level);
                    
                    AudioHandler.Instance.PlaySFX(successSFX);
                }
                break;
            case 54:
                if (barrierCD.UpgradeStat(51, level, 
                                          GameManager.Instance.PlayerCurrency))
                {
                    UpgradableStats.Instance().upgradeBarrierCD();
                    GameManager.Instance.PlayerCharacter.BarrierCooldownLevel++;
                    
                    UpgradableStats.Instance().SetBarrierCD(51);
                    GameManager.Instance.PlayerCharacter.BarrierCooldownTime = 51;
                    
                    UpdateCurrency(level);
                    
                    AudioHandler.Instance.PlaySFX(successSFX);
                }
                break;
            case 51:
                if (barrierCD.UpgradeStat(49, level, 
                                          GameManager.Instance.PlayerCurrency))
                {
                    UpgradableStats.Instance().upgradeBarrierCD();
                    GameManager.Instance.PlayerCharacter.BarrierCooldownLevel++;
                    
                    UpgradableStats.Instance().SetBarrierCD(49);
                    GameManager.Instance.PlayerCharacter.BarrierCooldownTime = 49;
                    
                    UpdateCurrency(level);
                    
                    AudioHandler.Instance.PlaySFX(successSFX);
                }
                break;
            case 49:
                if (barrierCD.UpgradeStat(46, level, 
                                          GameManager.Instance.PlayerCurrency))
                {
                    UpgradableStats.Instance().upgradeBarrierCD();
                    GameManager.Instance.PlayerCharacter.BarrierCooldownLevel++;
                    
                    UpgradableStats.Instance().SetBarrierCD(46);
                    GameManager.Instance.PlayerCharacter.BarrierCooldownTime = 46;
                    
                    UpdateCurrency(level);
                    
                    AudioHandler.Instance.PlaySFX(successSFX);
                }
                break;
            case 46:
                if (barrierCD.UpgradeStat(43, level, 
                                          GameManager.Instance.PlayerCurrency))
                {
                    UpgradableStats.Instance().upgradeBarrierCD();
                    GameManager.Instance.PlayerCharacter.BarrierCooldownLevel++;
                    
                    UpgradableStats.Instance().SetBarrierCD(43);
                    GameManager.Instance.PlayerCharacter.BarrierCooldownTime = 43;
                    
                    UpdateCurrency(level);
                    
                    AudioHandler.Instance.PlaySFX(successSFX);
                }
                break;
            case 43:
                if (barrierCD.UpgradeStat(40, level, 
                                          GameManager.Instance.PlayerCurrency))
                {
                    UpgradableStats.Instance().upgradeBarrierCD();
                    GameManager.Instance.PlayerCharacter.BarrierCooldownLevel++;
                    
                    UpgradableStats.Instance().SetBarrierCD(40);
                    GameManager.Instance.PlayerCharacter.BarrierCooldownTime = 40;
                    
                    UpdateCurrency(level);
                    
                    AudioHandler.Instance.PlaySFX(successSFX);
                }
                break;
            case 40:
                if (barrierCD.UpgradeStat(37, level, 
                                          GameManager.Instance.PlayerCurrency))
                {
                    UpgradableStats.Instance().upgradeBarrierCD();
                    GameManager.Instance.PlayerCharacter.BarrierCooldownLevel++;
                    
                    UpgradableStats.Instance().SetBarrierCD(37);
                    GameManager.Instance.PlayerCharacter.BarrierCooldownTime = 37;
                    
                    UpdateCurrency(level);
                    
                    AudioHandler.Instance.PlaySFX(successSFX);
                }
                break;
            case 37:
                if (barrierCD.UpgradeStat(35, level, 
                                          GameManager.Instance.PlayerCurrency))
                {
                    UpgradableStats.Instance().upgradeBarrierCD();
                    GameManager.Instance.PlayerCharacter.BarrierCooldownLevel++;
                    
                    UpgradableStats.Instance().SetBarrierCD(35);
                    GameManager.Instance.PlayerCharacter.BarrierCooldownTime = 35;
                    
                    UpdateCurrency(level);
                    
                    AudioHandler.Instance.PlaySFX(successSFX);
                }
                break;
            default:
                break;
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
        float knockback = GameManager.Instance.AmplifiedSpeakers.PushDistance;
        int   level     = GameManager.Instance.AmplifiedSpeakers.PowerLevel;
        
        switch (knockback)
        {
            case 1.0f:
                knockback = 1.25f;
                break;
            case 1.25f:
                knockback = 1.5f;
                break;
            case 1.5f:
                knockback = 1.75f;
                break;
            case 1.75f:
                knockback = 2.0f;
                break;
            case 2.0f:
                knockback = 2.5f;
                break;
            case 2.5f:
                knockback = 3.0f;
                break;
            case 3.0f:
                knockback = 3.5f;
                break;
            case 3.5f:
                knockback = 4.0f;
                break;
            case 4.0f:
                knockback = 5.0f;
                break;
            default:
                break;
        }
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
        float stunDuration = UpgradableStats.Instance().GetStaticBombDuration();
        int level = UpgradableStats.Instance().GetStaticBombLevel();
        switch(stunDuration)
        {
            case 0.2f:
                stunDuration = 0.25f;
                break;
            case 0.25f:
                stunDuration = 0.3f;
                break;
            case 0.3f:
                stunDuration = 0.35f;
                break;
            case 0.35f:
                stunDuration = 0.45f;
                break;
            case 0.45f:
                stunDuration = 0.55f;
                break;
            case 0.55f:
                stunDuration = 0.75f;
                break;
            case 0.75f:
                stunDuration = 0.95f;
                break;
            case 0.95f:
                stunDuration = 1.15f;
                break;
            case 1.15f:
                stunDuration = 1.25f;
                break;
            default:
                break;
        }
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
