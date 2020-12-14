using UnityEngine;

[System.Serializable]
public class SaveData
{
    #region Currency Data

    public int Coins = 0;
    public int KappaTokens = 0;    

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

    #endregion
    
    public SaveData(int coins = 0, int kappaTokens = 0)
    {
        // TODO: Initialize upgrades and level 1 data
        Coins       = coins;
        KappaTokens = kappaTokens;
    }
}
