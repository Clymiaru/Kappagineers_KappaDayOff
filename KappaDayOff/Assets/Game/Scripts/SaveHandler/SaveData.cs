using UnityEngine;

[System.Serializable]
public class SaveData
{
    #region Currency Data

    public int Coins;
    public int KappaTokens;    

    #endregion

    #region Weapon Data

    // Amplified Speakers
    // Water Ballon Launcher
    // Static Bomb

    #endregion
    
    #region Character Data

    // Character Data
    
    #endregion

    #region Level Data

    public LevelData LevelOneProgress;
    public LevelData LevelTwoProgress;
    public LevelData LevelThreeProgress;

    #endregion
    
    public SaveData(int coins = 0, int kappaTokens = 0)
    {
        Coins       = coins;
        KappaTokens = kappaTokens;
    }
}
