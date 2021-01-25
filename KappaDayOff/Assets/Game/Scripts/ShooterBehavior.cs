using System.Collections;
using UnityEngine;

public class ShooterBehavior : MonoBehaviour
{
	public enum EquippedWeapon
	{
		amplifiedSpeaker,
		waterBalloon,
		staticBomb
	}

	public GameObject bulletOriginPoint;
	public GameObject crosshair;
	public BulletPool objectPool;

	public  GameObject barrier;
	private float      balloonCD;

	private bool isShootingOnCooldown;

	private float speakerCD;
	private float staticBombCD;

	private void Awake()
	{
		speakerCD    = GameManager.Instance.AmplifiedSpeakers.CooldownTime;
		balloonCD    = GameManager.Instance.WaterBalloonLauncher.CooldownTime;
		staticBombCD = GameManager.Instance.StaticBomb.CooldownTime;
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
			var bullet = newBullet.GetComponent<BulletBehavior>();
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
			var bullet = newBullet.GetComponent<BulletBehavior>();
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
			var bullet = newBullet.GetComponent<BulletBehavior>();
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

		switch (weapon)
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