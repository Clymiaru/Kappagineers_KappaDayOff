using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int Coins;
    public int KappaTokens;

    public SaveData(int coins = 0, int kappaTokens = 0)
    {
        Coins       = coins;
        KappaTokens = kappaTokens;
    }
    
}
