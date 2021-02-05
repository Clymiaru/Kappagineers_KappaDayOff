using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Behavior : MonoBehaviour
{
	public GameObject player;
	public BulletPool objectPool;
	public float secondsPerPattern = 15.0f;
	private bool isCoolingDown;
	private bool isVisible;

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

		int RNG = Random.Range(0, 2);

		switch (RNG)
		{
			case 0:
				StartCoroutine(Pattern1());
				break;
			case 1:
				StartCoroutine(Pattern2());
				break;
		}

		yield return new WaitForSeconds(secondsPerPattern);
		isCoolingDown = false;
	}

	private IEnumerator Pattern1()
	{
		int bulletsForPattern = 5;
		float secondsPerShot = 2f;

		for (int i = 0; i < bulletsForPattern; i++)
		{
			GameObject newShot = objectPool.GetBoss2Bullet();
			newShot.transform.position = gameObject.transform.position;
			var shotBehavior = newShot.GetComponent<Boss2Bullet>();
			if (shotBehavior != null)
			{
				shotBehavior.SetBulletDestination(player.transform.position);
			}

			yield return new WaitForSeconds(secondsPerShot);
		}
	}

	private IEnumerator Pattern2()
	{
		int numberOfWaves = 5;
		int numberOfWavesLeft = numberOfWaves;
		int numberOfBulletsPerWave = 5;
		int BulletWaveSize = 5;
		float secondsPerShot = 0.3f;

		while (numberOfWavesLeft > 0)
		{
			Vector3 Direction = player.transform.position - gameObject.transform.position;
			for (int j = 0; j < BulletWaveSize; j++)
			{
				for (int i = 0; i < numberOfBulletsPerWave; i++)
				{
					GameObject newShot = objectPool.GetEnemyBullet();
					newShot.transform.position = gameObject.transform.position;
					var shotBehavior = newShot.GetComponent<BulletBehavior>();

					Vector3 newDirection;
					newDirection = new Vector3(Direction.x * Mathf.Cos(Mathf.Deg2Rad * (-(360 - 270 / numberOfWaves * (numberOfWaves - numberOfWavesLeft)) 
												/ numberOfBulletsPerWave * i)),
											Direction.y * -Mathf.Sin(Mathf.Deg2Rad * (-(360 - 270 / numberOfWaves * (numberOfWaves - numberOfWavesLeft))
												/ numberOfBulletsPerWave * i)), Direction.z);

					if (shotBehavior != null)
					{
						shotBehavior.SetBulletDestination(newDirection + gameObject.transform.position);
					}
				}

				yield return new WaitForSeconds(secondsPerShot);

			}

			yield return new WaitForSeconds(secondsPerShot * 3);

			numberOfWavesLeft--;
		}
	}
}
