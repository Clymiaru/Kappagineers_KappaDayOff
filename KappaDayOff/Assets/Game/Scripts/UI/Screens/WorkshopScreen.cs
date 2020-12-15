using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO: Finish workshop functionality and the screen
public class WorkshopScreen : MonoBehaviour
{
    
    [SerializeField] private List<Button> upgradeCategoryButtons = new List<Button>();

    [SerializeField] private GameObject characterUpgradesPanel = null;
    [SerializeField] private GameObject weaponUpgradesPanel = null;

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
        
    }
    
    public void OnBarrierCooldownUpgrade()
    {
        
    }
    
    public void OnAmplifiedSpeakersUpgrade()
    {
        
    }
    
    public void OnWaterBalloonLauncherUpgrade()
    {
        
    }
    
    public void OnStaticBombUpgrade()
    {
        
    }
}
