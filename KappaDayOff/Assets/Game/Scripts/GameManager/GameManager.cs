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

    [SerializeField] private string playerSaveFilename = "player";
    [SerializeField] private string playerSaveFileExtension = "dat";
    
    private void Awake()
    {
        Instance = this;
        
        // Load TitleScreen
        // Initialize main menu

        // if the player taps anywhere on the screen, load their save data
    }

    private void Start()
    {
        // Initialize game state
        SceneLoader.Instance.LoadScene(SceneNames.Intro);
    }

    // Player in general
    // * Currency Data
    public int Coins       { get; private set; } = 0;
    public int KappaTokens { get; private set; } = 0;
    
    // * Upgrade levels (Weapons and character)
    
    // * Level Progress Data
        // Level Progress Data
        // * Level ID / Name
        // * Completion State (Not Started, Has Tried, Completed)
        // * Highscore Achieved
    

    public void InitializePlayerData()
    {
        var playerData = SaveHandler.Instance.Load($"{playerSaveFilename}.{playerSaveFileExtension}");

        if (playerData == null)
        {
            // This is a new player, create a new save file with initial values
            return;
        }
        
        // This player has played before, get their previous progress
        Coins       = playerData.Coins;
        KappaTokens = playerData.KappaTokens;
    }

    // Do this at least before quitting the game
    public void SavePlayerData()
    {
        // Update save data
        var playerData = new SaveData();
        
        playerData.Coins       = Coins;
        playerData.KappaTokens = KappaTokens;
        
        SaveHandler.Instance.Save(playerData, $"{playerSaveFilename}.{playerSaveFileExtension}");
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
        Coins       = int.MaxValue;
        KappaTokens = int.MaxValue;
    }
    
    #endregion

}
