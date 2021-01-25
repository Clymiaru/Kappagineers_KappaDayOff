﻿using System.Collections;
using UnityEngine;

public class EnemyShooterBehavior : MonoBehaviour
{
	public  GameObject player;
	public  BulletPool objectPool;
	public  float      secondsPerShot = 1.0f;
	private bool       isCoolingDown;
	private bool       isVisible;

	private void Update()
	{
		if (!isCoolingDown && player != null && isVisible)
		{
			StartCoroutine(Shoot());
		}
	}

	private void OnBecameInvisible()
	{
		isVisible = false;
	}

	private void OnBecameVisible()
	{
		isVisible = true;
	}

	private IEnumerator Shoot()
	{
		isCoolingDown = true;

		GameObject newShot = objectPool.GetEnemyBullet();
		newShot.transform.position = gameObject.transform.position;
		var shotBehavior = newShot.GetComponent<BulletBehavior>();
		if (shotBehavior != null)
		{
			shotBehavior.SetBulletDestination(player.transform.position);
		}

		yield return new WaitForSeconds(secondsPerShot);
		isCoolingDown = false;
	}
}