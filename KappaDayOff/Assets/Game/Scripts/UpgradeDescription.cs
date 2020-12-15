using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeDescription : MonoBehaviour
{
    private int upgradeLevel = 1;
    [SerializeField] private string statMessage;
    [SerializeField] private string statMessage2;
    [SerializeField] private string statMessage3;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text statText;

    public bool UpgradeStat(int newValue)
    {
        if (upgradeLevel < 10)
        {
            upgradeLevel++;
            levelText.text = "Level " + upgradeLevel;
            statText.text = string.Format("{0} {1}", statMessage, newValue);
            return true;
        }
        else
            return false;
    }

    public bool UpgradeStat(float newValue)
    {
        if (upgradeLevel < 10)
        {
            upgradeLevel++;
            levelText.text = "Level " + upgradeLevel;
            statText.text = string.Format("{0} {1:#.00}", statMessage, newValue);
            return true;
        }
        else
            return false;
    }

    public bool UpgradeStats(int newPower, float CD, float secondaryEffect = 0)
    {
        if (upgradeLevel < 10)
        {
            upgradeLevel++;
            levelText.text = "Level " + upgradeLevel;
            if (secondaryEffect != 0)
                statText.text = string.Format("{0} {1}\n{2} {3:#.00}\n{4} {5:#.00}",
                    statMessage, newPower, statMessage2, CD, statMessage3, secondaryEffect);
            else
                statText.text = string.Format("{0} {1}\n{2} {3:#.00}", statMessage, newPower, statMessage2, CD);
            return true;
        }
        else
            return false;
    }
}
