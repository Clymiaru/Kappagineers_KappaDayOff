using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehavior : MonoBehaviour
{
    public GameObject bulletOriginPoint;
    public GameObject crosshair;
    public BulletPool objectPool;

    private float speakerCD;
    private float balloonCD;
    private float staticBombCD;

    public GameObject barrier;

    public enum EquippedWeapon
    {
        amplifiedSpeaker, waterBalloon, staticBomb
    }

    private bool isShootingOnCooldown = false;

    private void Awake()
    {
        speakerCD = UpgradableStats.Instance().GetSpeakerCD();
        balloonCD = UpgradableStats.Instance().GetWaterBalloonCD();
        staticBombCD = UpgradableStats.Instance().GetStaticBombCD();
    }

    /*public void SwitchGunLeft()
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
        if (!isShootingOnCooldown && !barrier.activeSelf)
        {
            GameObject newBullet = null;

            switch (weapon)
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
            StartCoroutine(BeginCooldown(weapon));
        }
    }*/

    public void ShootSpeaker()
    {
        if (!isShootingOnCooldown && !barrier.activeSelf)
        {
            GameObject newBullet = objectPool.GetAmplifiedWave();

            newBullet.transform.position = bulletOriginPoint.transform.position;
            BulletBehavior bullet = newBullet.GetComponent<BulletBehavior>();
            if (bullet != null)
            {
                bullet.SetBulletDestination(crosshair.transform.position);
            }
            StartCoroutine(BeginCooldown(EquippedWeapon.amplifiedSpeaker));
        }
    }

    public void ShootStaticBomb()
    {
        if (!isShootingOnCooldown && !barrier.activeSelf)
        {
            GameObject newBullet = objectPool.GetStaticBomb();

            newBullet.transform.position = bulletOriginPoint.transform.position;
            BulletBehavior bullet = newBullet.GetComponent<BulletBehavior>();
            if (bullet != null)
            {
                bullet.SetBulletDestination(crosshair.transform.position);
            }
            StartCoroutine(BeginCooldown(EquippedWeapon.staticBomb));
        }
    }

    public void ShootWaterBalloon()
    {
        if (!isShootingOnCooldown && !barrier.activeSelf)
        {
            GameObject newBullet = objectPool.GetWaterBalloon();

            newBullet.transform.position = bulletOriginPoint.transform.position;
            BulletBehavior bullet = newBullet.GetComponent<BulletBehavior>();
            if (bullet != null)
            {
                bullet.SetBulletDestination(crosshair.transform.position);
            }
            StartCoroutine(BeginCooldown(EquippedWeapon.waterBalloon));
        }
    }

    private IEnumerator BeginCooldown(EquippedWeapon weapon)
    {
        isShootingOnCooldown = true;

        switch(weapon)
        {
            case EquippedWeapon.amplifiedSpeaker:
                yield return new WaitForSeconds(speakerCD);
                break;
            case EquippedWeapon.waterBalloon:
                yield return new WaitForSeconds(balloonCD);
                break;
            case EquippedWeapon.staticBomb:
                yield return new WaitForSeconds(staticBombCD);
                break;
        }

        isShootingOnCooldown = false;
    }
}
