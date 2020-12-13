using UnityEngine;

public class SaveTestScreen : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text valueText = null;

    private int coins = 0;
    
    private void Update()
    {
        valueText.text = coins.ToString();
    }

    public void OnAddCoins()
    {
        coins += 10;
        coins = Mathf.Min(coins, 999999);
    }

    public void OnSubtractCoins()
    {
        coins -= 10;
        coins = Mathf.Max(coins, 0);
    }

    public void OnSaveData()
    {
        var data = new SaveData(coins, 0);
        SaveHandler.Instance.Save(data);
    }

    public void OnLoadData()
    {
        var data = SaveHandler.Instance.Load();
        if (data != null)
        {
            coins = data.Coins;
        }
    }
    
    
    
}
