using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Behavior : MonoBehaviour
{
	public GameObject player;
	public BulletPool objectPool;
	public float secondsPerPattern = 15.0f;
	public float secondsPerShot = 0.5f;
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

		switch(RNG)
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
        }

		yield return new WaitForSeconds(secondsPerPattern);
		isCoolingDown = false;
	}

	private IEnumerator Pattern1(float waveArc)
    {
		int numberOfWavesLeft = 10;
		int numberOfBulletsPerWave = 10 * Mathf.FloorToInt(waveArc / 180);

		while (numberOfWavesLeft > 0)
        {
			Vector3 Direction = player.transform.position - gameObject.transform.position;
			for (int i = 0; i < numberOfBulletsPerWave; i++)
			{
				GameObject newShot = objectPool.GetEnemyBullet();
				newShot.transform.position = gameObject.transform.position;
				var shotBehavior = newShot.GetComponent<BulletBehavior>();

				Vector3 newDirection;
				if (numberOfWavesLeft % 2 == 0)
				{
					newDirection = new Vector3(Direction.x * Mathf.Cos(Mathf.Deg2Rad * (-45 + waveArc / numberOfBulletsPerWave * i)),
											Direction.y * -Mathf.Sin(Mathf.Deg2Rad * (-45 + waveArc / numberOfBulletsPerWave * i)), Direction.z);
				}
				else
                {
					newDirection = new Vector3(Direction.x * Mathf.Cos(Mathf.Deg2Rad * (45 - waveArc / numberOfBulletsPerWave * i)),
											Direction.y * -Mathf.Sin(Mathf.Deg2Rad * (45 - waveArc / numberOfBulletsPerWave * i)), Direction.z);
				}

				if (shotBehavior != null)
				{
					shotBehavior.SetBulletDestination(newDirection + gameObject.transform.position);
				}
			}

			yield return new WaitForSeconds(secondsPerShot);

			numberOfWavesLeft--;
        }
    }

	private IEnumerator Pattern2()
    {
		int numberOfWavesLeft = 10;
		int numberOfSoloBulletsPerWave = 10;
		int numberOfCircleBulletsPerWave = 15;
		
		while (numberOfWavesLeft > 0)
		{
			for (int i = 0; i < numberOfSoloBulletsPerWave; i++)
			{
				GameObject newShot = objectPool.GetEnemyBullet();
				newShot.transform.position = gameObject.transform.position;
				var shotBehavior = newShot.GetComponent<BulletBehavior>();

				float randomDirection = Random.Range(0, 360) * Mathf.Deg2Rad;
				Vector3 newDirection = new Vector3(1 * Mathf.Cos(randomDirection), 1 * -Mathf.Sin(randomDirection), 
					player.transform.position.z - gameObject.transform.position.z);

				if (shotBehavior != null)
				{
					shotBehavior.SetBulletDestination(newDirection + gameObject.transform.position);
					shotBehavior.SetBulletSpeed(0.5f * Random.value);
				}

				yield return new WaitForSeconds(secondsPerShot);
			}


			Vector3 Direction = player.transform.position - gameObject.transform.position;
			for (int i = 0; i < numberOfCircleBulletsPerWave; i++)
			{
				GameObject newShot = objectPool.GetEnemyBullet();
				newShot.transform.position = gameObject.transform.position;
				var shotBehavior = newShot.GetComponent<BulletBehavior>();

				Vector3 newDirection;
				if (numberOfWavesLeft % 2 == 0)
				{
					newDirection = new Vector3(Direction.x * Mathf.Cos(Mathf.Deg2Rad * (-45 + 360 / numberOfCircleBulletsPerWave * i)),
											Direction.y * -Mathf.Sin(Mathf.Deg2Rad * (-45 + 360 / numberOfCircleBulletsPerWave * i)), Direction.z);
				}
				else
				{
					newDirection = new Vector3(Direction.x * Mathf.Cos(Mathf.Deg2Rad * (45 - 360 / numberOfCircleBulletsPerWave * i)),
											Direction.y * -Mathf.Sin(Mathf.Deg2Rad * (45 - 360 / numberOfCircleBulletsPerWave * i)), Direction.z);
				}

				if (shotBehavior != null)
				{
					shotBehavior.SetBulletDestination(newDirection + gameObject.transform.position);
				}
			}

			yield return new WaitForSeconds(secondsPerShot);

			numberOfWavesLeft--;
		}
	}
}
