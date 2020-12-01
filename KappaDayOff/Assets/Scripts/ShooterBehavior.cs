using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehavior : MonoBehaviour
{
    public GameObject bulletOriginPoint;
    public GameObject crosshair;
    public GameObject[] bulletPrefabs;

    private int chosenBulletIndex = 0;

    public void SwitchGunLeft()
    {
        if (chosenBulletIndex > 0)
            chosenBulletIndex--;
        else
            chosenBulletIndex = bulletPrefabs.Length - 1;
    }

    public void SwitchGunRight()
    {
        if (chosenBulletIndex < bulletPrefabs.Length - 1)
            chosenBulletIndex++;
        else
            chosenBulletIndex = 0;
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefabs[chosenBulletIndex], bulletOriginPoint.transform.position, Quaternion.identity);
        BulletBehavior bullet = newBullet.GetComponent<BulletBehavior>();
        if (bullet != null)
            bullet.SetBulletDestination(crosshair.transform.position);
    }
}
