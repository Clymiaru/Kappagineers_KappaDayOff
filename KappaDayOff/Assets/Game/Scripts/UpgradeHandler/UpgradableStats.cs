using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradableStats
{
    public static UpgradableStats sharedInstance;

    public static UpgradableStats Instance()
    {
        if (sharedInstance == null)
            sharedInstance = new UpgradableStats();
        return sharedInstance;
    }

    private UpgradableStats()
    {

    }

    private int playerHPLevel = 1;
    private int playerHP = 50;
    private int barrierCDLevel = 1;
    private float barrierCD = 60;

    private int amplifiedSpeakerLevel = 1;
    private int amplifiedSpeakersPower = 10;
    private float amplifiedSpeakersCD = 1;
    private float amplifiedSpeakersPushDistance = 1;

    private int waterBalloonLevel = 1;
    private int waterBalloonPower = 10;
    private float waterBalloonCD = 1;

    private int staticBombLevel = 1;
    private int staticBombPower = 10;
    private float staticBombCD = 1;
    private float staticBombDuration = 0.2f;

    public void ResetUpgrades()
    {
        playerHPLevel = 1;
        playerHP = 50;
        barrierCDLevel = 1;
        barrierCD = 60;

        amplifiedSpeakerLevel = 1;
        amplifiedSpeakersPower = 10;
        amplifiedSpeakersCD = 1;
        amplifiedSpeakersPushDistance = 1;

        waterBalloonLevel = 1;
        waterBalloonPower = 10;
        waterBalloonCD = 1;

        staticBombLevel = 1;
        staticBombPower = 10;
        staticBombCD = 1;
        staticBombDuration = 0.2f;
    }

    public int GetPlayerHP()
    {
        return playerHP;
    }

    public void SetPlayerHP(int HP)
    {
        playerHP = HP;
    }

    public float GetBarrierCD()
    {
        return barrierCD;
    }

    public void SetBarrierCD(float CD)
    {
        barrierCD = CD;
    }

    public int GetSpeakerPower()
    {
        return amplifiedSpeakersPower;
    }

    public void SetSpeakerPower(int power)
    {
        amplifiedSpeakersPower = power;
    }
    
    public float GetSpeakerCD()
    {
        return amplifiedSpeakersCD;
    }

    public void SetSpeakerCD(float CD)
    {
        amplifiedSpeakersCD = CD;
    }
    
    public float GetSpeakerPushDistance()
    {
        return amplifiedSpeakersPushDistance;
    }

    public void SetSpeakerPushDistance(float distance)
    {
        amplifiedSpeakersPushDistance = distance;
    } 
  
    public int GetWaterBalloonPower()
    {
        return waterBalloonPower;
    }

    public void SetWaterBalloonPower(int power)
    {
        waterBalloonPower = power;
    }
    
    public float GetWaterBalloonCD()
    {
        return waterBalloonCD;
    }

    public void SetWaterBalloonCD(float CD)
    {
        waterBalloonCD = CD;
    }
   
    public int GetStaticBombPower()
    {
        return staticBombPower;
    }

    public void SetStaticBombPower(int power)
    {
        staticBombPower = power;
    }
    
    public float GetStaticBombCD()
    {
        return staticBombCD;
    }

    public void SetStaticBombCD(float CD)
    {
        staticBombCD = CD;
    }
    
    public float GetStaticBombDuration()
    {
        return staticBombDuration;
    }

    public void SetStaticBombDuration(float duration)
    {
        staticBombDuration = duration;
    }

    public int GetPlayerHPLevel()
    {
        return playerHPLevel;
    }

    public void upgradePlayerHP()
    {
        playerHPLevel++;
    }

    public int GetBarrierCDLevel()
    {
        return barrierCDLevel;
    }

    public void upgradeBarrierCD()
    {
        barrierCDLevel++;
    }

    public int GetAmplifiedSpeakersLevel()
    {
        return amplifiedSpeakerLevel;
    }

    public void upgradeAmplifiedSpeakers()
    {
        amplifiedSpeakerLevel++;
    }

    public int GetWaterBalloonLevel()
    {
        return waterBalloonLevel;
    }

    public void upgradeWaterBalloon()
    {
        waterBalloonLevel++;
    }

    public int GetStaticBombLevel()
    {
        return staticBombLevel;
    }

    public void upgradeStaticBomb()
    {
        staticBombLevel++;
    }
}
