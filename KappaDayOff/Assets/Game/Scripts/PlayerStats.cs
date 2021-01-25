using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int HP = 50;
    public AdsManager adsManager;

    private void Start()
    {
        HP = GameManager.Instance.PlayerCharacter.MaxHP;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            adsManager.ShowInterstitialAd();
            Destroy(gameObject);
            SceneLoader.Instance.LoadScene(SceneNames.MainMenu);
        }
    }
}
