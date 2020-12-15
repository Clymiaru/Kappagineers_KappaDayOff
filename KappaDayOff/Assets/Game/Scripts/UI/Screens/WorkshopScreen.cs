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

    private GameObject currentPanelSelected = null;
    
    private int optionIndex = 0; // For now, auto-select the first option

    private void Awake()
    {
    }

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
        currentPanelSelected.SetActive(false);
        currentPanelSelected = characterUpgradesPanel.gameObject;
        currentPanelSelected.SetActive(true);
        optionIndex = 0;
    }

    public void OnWeaponUpgradesSelect()
    {
        currentPanelSelected.SetActive(false);
        currentPanelSelected = weaponUpgradesPanel.gameObject;
        currentPanelSelected.SetActive(true);
        optionIndex = 1;
    }

    public void OnExitScreen()
    {
        gameObject.SetActive(false);
    }

    public void OnMaxHPUpgrade()
    {
        int HP = UpgradableStats.Instance().GetPlayerHP() + 50;
        if(playerHP.UpgradeStat(HP))
        {
            UpgradableStats.Instance().SetPlayerHP(HP);
        }
    }
    
    public void OnBarrierCooldownUpgrade()
    {
        float CD = UpgradableStats.Instance().GetBarrierCD();
        switch (CD)
        {
            case 60:
                if (barrierCD.UpgradeStat(57))
                {
                    UpgradableStats.Instance().SetBarrierCD(57);
                }
                break;
            case 57:
                if (barrierCD.UpgradeStat(54))
                {
                    UpgradableStats.Instance().SetBarrierCD(54);
                }
                break;
            case 54:
                if (barrierCD.UpgradeStat(51))
                {
                    UpgradableStats.Instance().SetBarrierCD(51);
                }
                break;
            case 51:
                if (barrierCD.UpgradeStat(49))
                {
                    UpgradableStats.Instance().SetBarrierCD(49);
                }
                break;
            case 49:
                if (barrierCD.UpgradeStat(46))
                {
                    UpgradableStats.Instance().SetBarrierCD(46);
                }
                break;
            case 46:
                if (barrierCD.UpgradeStat(43))
                {
                    UpgradableStats.Instance().SetBarrierCD(43);
                }
                break;
            case 43:
                if (barrierCD.UpgradeStat(40))
                {
                    UpgradableStats.Instance().SetBarrierCD(40);
                }
                break;
            case 40:
                if (barrierCD.UpgradeStat(37))
                {
                    UpgradableStats.Instance().SetBarrierCD(37);
                }
                break;
            case 37:
                if (barrierCD.UpgradeStat(35))
                {
                    UpgradableStats.Instance().SetBarrierCD(35);
                }
                break;
            default:
                break;
        }
    }
    
    public void OnAmplifiedSpeakersUpgrade()
    {
        int power = UpgradableStats.Instance().GetSpeakerPower() + 5;
        float CD = UpgradableStats.Instance().GetSpeakerCD() - 0.1f;
        float knockback = UpgradableStats.Instance().GetSpeakerPushDistance();
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
        if (amplifiedSpeakersUpgrade.UpgradeStats(power, CD, knockback))
        {
            UpgradableStats.Instance().SetSpeakerPower(power);
            UpgradableStats.Instance().SetSpeakerCD(CD);
            UpgradableStats.Instance().SetSpeakerPushDistance(knockback);
        }
    }
    
    public void OnWaterBalloonLauncherUpgrade()
    {
        int power = UpgradableStats.Instance().GetWaterBalloonPower() + 5;
        float CD = UpgradableStats.Instance().GetWaterBalloonCD() - 0.1f;
        if (waterBalloonUpgrade.UpgradeStats(power, CD))
        {
            UpgradableStats.Instance().SetWaterBalloonPower(power);
            UpgradableStats.Instance().SetWaterBalloonCD(CD);
        }
    }
    
    public void OnStaticBombUpgrade()
    {
        int power = UpgradableStats.Instance().GetStaticBombPower() + 5;
        float CD = UpgradableStats.Instance().GetStaticBombCD() - 0.1f;
        float stunDuration = UpgradableStats.Instance().GetStaticBombDuration();
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
        if (staticBombUpgrade.UpgradeStats(power, CD, stunDuration))
        {
            UpgradableStats.Instance().SetStaticBombPower(power);
            UpgradableStats.Instance().SetStaticBombCD(CD);
            UpgradableStats.Instance().SetStaticBombDuration(stunDuration);
        }
    }
}
