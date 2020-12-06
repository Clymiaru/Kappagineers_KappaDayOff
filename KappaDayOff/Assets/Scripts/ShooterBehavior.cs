using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehavior : MonoBehaviour
{
    public GameObject bulletOriginPoint;
    public GameObject crosshair;
    public BulletPool objectPool;
    
    public float[] gunCooldowns;

    private enum EquippedWeapon
    {
        amplifiedSpeaker, waterBalloon, staticBomb
    }

    private EquippedWeapon chosenWeapon = EquippedWeapon.amplifiedSpeaker;
    private bool isShootingOnCooldown = false;

    public void SwitchGunLeft()
    {
        switch(chosenWeapon)
        {
            case EquippedWeapon.amplifiedSpeaker:
                chosenWeapon = EquippedWeapon.staticBomb;
                break;
            case EquippedWeapon.staticBomb:
                chosenWeapon = EquippedWeapon.waterBalloon;
                break;
            case EquippedWeapon.waterBalloon:
                chosenWeapon = EquippedWeapon.amplifiedSpeaker;
                break;
        }
    }

    public void SwitchGunRight()
    {
        switch (chosenWeapon)
        {
            case EquippedWeapon.amplifiedSpeaker:
                chosenWeapon = EquippedWeapon.waterBalloon;
                break;
            case EquippedWeapon.staticBomb:
                chosenWeapon = EquippedWeapon.amplifiedSpeaker;
                break;
            case EquippedWeapon.waterBalloon:
                chosenWeapon = EquippedWeapon.staticBomb;
                break;
        }
    }

    public void Shoot()
    {
        if (!isShootingOnCooldown)
        {
            GameObject newBullet = null;

            switch (chosenWeapon)
            {
                case EquippedWeapon.amplifiedSpeaker:
                    newBullet = objectPool.GetAmplifiedWave();
                    break;
                case EquippedWeapon.staticBomb:
                    newBullet = objectPool.GetStaticBomb();
                    break;
                case EquippedWeapon.waterBalloon:
                    newBullet = objectPool.GetWaterBalloon();
                    break;
            }

            newBullet.transform.position = bulletOriginPoint.transform.position;
            BulletBehavior bullet = newBullet.GetComponent<BulletBehavior>();
            if (bullet != null)
            {
                bullet.SetBulletDestination(crosshair.transform.position);
            }
            StartCoroutine(BeginCooldown());
        }
    }

    private IEnumerator BeginCooldown()
    {
        isShootingOnCooldown = true;

        switch(chosenWeapon)
        {
            case EquippedWeapon.amplifiedSpeaker:
                yield return new WaitForSeconds(gunCooldowns[0]);
                break;
            case EquippedWeapon.waterBalloon:
                yield return new WaitForSeconds(gunCooldowns[1]);
                break;
            case EquippedWeapon.staticBomb:
                yield return new WaitForSeconds(gunCooldowns[2]);
                break;
        }

        isShootingOnCooldown = false;
    }
}
