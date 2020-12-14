using System;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager sharedInstance = null;
    public static GameManager Instance 
    {
        get => sharedInstance;
        private set => sharedInstance = value;
    }
    
    private const string PlayerSaveFileName = "player";
    
    public bool IsPaused { get; private set; } = false;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Load all saved global data
        InitializePlayerData();
    }

    private void OnDestroy()
    {
        SavePlayerData();
    }

    #region Global Game Data
    
    public CurrencyData PlayerCurrency    { get; private set; } = new CurrencyData();
    public UpgradeData  PlayerUpgradeData { get; private set; } = new UpgradeData();
    public LevelData    LevelOneProgress  { get; private set; } = new LevelData();
    
    #endregion

    public void UpdateCurrency(CurrencyType currency, int amountAdded)
    {
        if (currency == CurrencyType.COIN)
        {
            PlayerCurrency.Coins += amountAdded;
            PlayerCurrency.Coins =  Mathf.Max(PlayerCurrency.Coins, 0);
        }
        else if (currency == CurrencyType.KAPPA_TOKEN)
        {
            PlayerCurrency.KappaTokens += amountAdded;
            PlayerCurrency.KappaTokens =  Mathf.Max(PlayerCurrency.KappaTokens, 0);
        }
    }

    public void InitializePlayerData()
    {
        var playerData = SaveHandler.Instance.Load(PlayerSaveFileName);

        if (playerData == null)
        {
            playerData = CreateNewPlayerSave();
        }
        
        // TODO: Initialize upgrades and level 1 data
        PlayerCurrency.Coins = playerData.Coins;
        PlayerCurrency.KappaTokens = playerData.KappaTokens;
    }

    private SaveData CreateNewPlayerSave()
    {
        var playerData = new SaveData();
        SaveHandler.Instance.Save(playerData, PlayerSaveFileName);
        return playerData;
    }
    
    public void SavePlayerData()
    {
        // TODO: Call when the game ends or in key events
        var playerData = new SaveData();
        
        playerData.Coins       = PlayerCurrency.Coins;
        playerData.KappaTokens = PlayerCurrency.KappaTokens;
        
        SaveHandler.Instance.Save(playerData, PlayerSaveFileName);
    }

    #region Developer Options

    // TODO: Ask if a debug option is chosen, does it save to the player data?
    public void GenerateNotification()
    {
        
    }

    public void UnlockAllLevels()
    {
        
    }

    public void UnlimitedMoney()
    {
        PlayerCurrency.Coins       = int.MaxValue;
        PlayerCurrency.KappaTokens = int.MaxValue;
        Debug.Log("DEBUG: Unlimited Money");
    }
    
    public void ResetPlayerProgress()
    {
        PlayerCurrency.Coins       = 1000;
        PlayerCurrency.KappaTokens = 3;
        Debug.Log("DEBUG: Reset Player Progress");
    }

    public void ChangeTimeOfDay()
    {
        
    }

    public void NotificationInterval()
    {
        
    }
    
    #endregion

}
