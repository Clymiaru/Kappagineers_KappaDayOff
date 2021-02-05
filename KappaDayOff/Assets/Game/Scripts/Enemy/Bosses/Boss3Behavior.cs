using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Behavior : MonoBehaviour
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

		int RNG = Random.Range(0, 3);
		StartCoroutine(Pattern3());
		/*switch (RNG)
		{
			case 0:
				StartCoroutine(Pattern1(180f));
				break;
			case 1:
				StartCoroutine(Pattern1(360f));
				break;
			case 2:
				StartCoroutine(Pattern2());
				break;
		}*/

		yield return new WaitForSeconds(secondsPerPattern);
		isCoolingDown = false;
	}

	private IEnumerator Pattern1()
	{
		int numberOfWavesLeft = 10;
		int numberOfBulletsPerWave = 20;
		int numberOfChargingBullets = 5;
		float waveArc = 360;
		float secondsPerShot = 0.2f;

		while (numberOfWavesLeft > 0)
		{
			Vector3 spawnLocation = gameObject.transform.position + Vector3.up * (5 - 10 * Random.value);

			Vector3 Direction = player.transform.position - spawnLocation;
			for (int i = 0; i < numberOfBulletsPerWave; i++)
			{
				GameObject newShot = objectPool.GetEnemyBullet();
				newShot.transform.position = spawnLocation;
				var shotBehavior = newShot.GetComponent<BulletBehavior>();

				Vector3 newDirection;

				newDirection = new Vector3(Direction.x * Mathf.Cos(Mathf.Deg2Rad * (- waveArc / numberOfBulletsPerWave * i)),
										Direction.y * -Mathf.Sin(Mathf.Deg2Rad * (- waveArc / numberOfBulletsPerWave * i)), Direction.z);


				if (shotBehavior != null)
				{
					shotBehavior.SetBulletDestination(newDirection + spawnLocation);
				}
			}

			for (int i = 0; i < numberOfChargingBullets; i++)
			{
				GameObject newShot = objectPool.GetEnemyBullet();
				newShot.transform.position = spawnLocation;
				var shotBehavior = newShot.GetComponent<BulletBehavior>();

				if (shotBehavior != null)
				{
					shotBehavior.SetBulletDestination(player.transform.position);
				}
				yield return new WaitForSeconds(secondsPerShot);
			}

			numberOfWavesLeft--;
		}
	}

	private IEnumerator Pattern2()
	{
		int numberOfWavesLeft = 2;
		int numberOfBulletsPerWave = 10;
		int waveCount = 5;
		float waveArc = 360;
		float focusArc = 120;
		float secondsPerShot = 0.2f;

		while (numberOfWavesLeft > 0)
		{
			Vector3 Direction = player.transform.position - gameObject.transform.position;
			for (int j = 0; j < waveCount; j++)
			{
				for (int i = 0; i < numberOfBulletsPerWave; i++)
				{
					GameObject newShot = objectPool.GetEnemyBullet();
					newShot.transform.position = gameObject.transform.position;
					var shotBehavior = newShot.GetComponent<BulletBehavior>();

					Vector3 newDirection;
					newDirection = new Vector3(Direction.x * Mathf.Cos(Mathf.Deg2Rad * (-waveArc / numberOfBulletsPerWave * i)),
											Direction.y * -Mathf.Sin(Mathf.Deg2Rad * (-waveArc / numberOfBulletsPerWave * i)), Direction.z);

					if (shotBehavior != null)
					{
						shotBehavior.SetBulletDestination(newDirection + gameObject.transform.position);
						shotBehavior.SetBulletSpeed(0.05f);
					}
				}
				yield return new WaitForSeconds(secondsPerShot);
			}

			for (int j = 0; j < waveCount; j++)
			{
				for (int i = 0; i < numberOfBulletsPerWave; i++)
				{
					GameObject newShot = objectPool.GetEnemyBullet();
					newShot.transform.position = gameObject.transform.position;
					var shotBehavior = newShot.GetComponent<BulletBehavior>();

					Vector3 newDirection;
					newDirection = new Vector3(Direction.x * Mathf.Cos(Mathf.Deg2Rad * (-focusArc / numberOfBulletsPerWave * i)),
											Direction.y * -Mathf.Sin(Mathf.Deg2Rad * (-focusArc / numberOfBulletsPerWave * i)), Direction.z);

					if (shotBehavior != null)
					{
						shotBehavior.SetBulletDestination(newDirection + gameObject.transform.position);
						shotBehavior.SetBulletSpeed(0.3f);
					}
				}
				yield return new WaitForSeconds(secondsPerShot);
			}

			numberOfWavesLeft--;
		}
	}

	private IEnumerator Pattern3()
	{
		int numberOfWavesLeft = 10;
		int numberOfBulletsPerWave = 20;
		float secondsPerShot = 0.1f;

		while (numberOfWavesLeft > 0)
		{
			for (int i = 0; i < numberOfBulletsPerWave; i++)
			{
				GameObject newShot = objectPool.GetEnemyBullet();
				newShot.transform.position = gameObject.transform.position;
				var shotBehavior = newShot.GetComponent<BulletBehavior>();

				if (shotBehavior != null)
				{
					shotBehavior.SetBulletDestination(player.transform.position);
					shotBehavior.SetBulletSpeed(-0.2f);
					shotBehavior.setAcceleration(0.1f);
				}
				yield return new WaitForSeconds(secondsPerShot);
			}	

			numberOfWavesLeft--;
		}
	}
}
