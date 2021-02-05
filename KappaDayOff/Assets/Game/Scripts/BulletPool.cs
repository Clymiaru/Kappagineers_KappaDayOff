using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
	public static BulletPool Instance;

	public GameObject waterBallonBase;
	public GameObject amplifiedWaveBase;
	public GameObject staticBombBase;

	public           GameObject       enemyBulletBase;
	public           GameObject       Boss2BulletBase;
	private readonly List<GameObject> activeAmplifiedWaves = new List<GameObject>();

	private readonly List<GameObject> activeEnemyBullets = new List<GameObject>();
	private readonly List<GameObject> activeBoss2Bullets = new List<GameObject>();
	private readonly List<GameObject> activeStaticBombs  = new List<GameObject>();

	private readonly List<GameObject> activeWaterBalloons    = new List<GameObject>();
	private readonly List<GameObject> inactiveAmplifiedWaves = new List<GameObject>();
	private readonly List<GameObject> inactiveEnemyBullets   = new List<GameObject>();
	private readonly List<GameObject> inactiveBoss2Bullets   = new List<GameObject>();
	private readonly List<GameObject> inactiveStaticBombs    = new List<GameObject>();
	private readonly List<GameObject> inactiveWaterBalloons  = new List<GameObject>();

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}

	private void GeneratePlayerBullets()
	{
		for (int i = 0; i < 10; i++)
		{
			GameObject newWaterBalloon = Instantiate(waterBallonBase, Camera.main.transform);
			inactiveWaterBalloons.Add(newWaterBalloon);
			newWaterBalloon.GetComponent<BulletBehavior>().SetBulletPool(Instance);
			newWaterBalloon.SetActive(false);

			GameObject newStaticBomb = Instantiate(staticBombBase, Camera.main.transform);
			inactiveStaticBombs.Add(newStaticBomb);
			newStaticBomb.GetComponent<BulletBehavior>().SetBulletPool(Instance);
			newStaticBomb.SetActive(false);

			GameObject newAmplifiedWaves = Instantiate(amplifiedWaveBase, Camera.main.transform);
			inactiveAmplifiedWaves.Add(newAmplifiedWaves);
			newAmplifiedWaves.GetComponent<BulletBehavior>().SetBulletPool(Instance);
			newAmplifiedWaves.SetActive(false);
		}
	}

	private void GenerateEnemyBullets()
	{
		for (int i = 0; i < 10; i++)
		{
			GameObject newEnemyBullet = Instantiate(enemyBulletBase);
			inactiveEnemyBullets.Add(newEnemyBullet);
			newEnemyBullet.GetComponent<BulletBehavior>().SetBulletPool(Instance);
			newEnemyBullet.SetActive(false);
		}
	}

	private void GenerateBossBullets()
    {
		GameObject newBoss2Bullet = Instantiate(Boss2BulletBase);
		inactiveBoss2Bullets.Add(newBoss2Bullet);
		newBoss2Bullet.GetComponent<BulletBehavior>().SetBulletPool(Instance);
		newBoss2Bullet.SetActive(false);
	}

	public GameObject GetWaterBalloon()
	{
		if (inactiveWaterBalloons.Count == 0)
		{
			GeneratePlayerBullets();
		}

		GameObject balloon = inactiveWaterBalloons[inactiveWaterBalloons.Count - 1];
		balloon.SetActive(true);
		activeWaterBalloons.Add(balloon);
		inactiveWaterBalloons.Remove(balloon);

		return balloon;
	}

	public GameObject GetAmplifiedWave()
	{
		if (inactiveAmplifiedWaves.Count == 0)
		{
			GeneratePlayerBullets();
		}

		GameObject wave = inactiveAmplifiedWaves[inactiveAmplifiedWaves.Count - 1];
		wave.SetActive(true);
		activeAmplifiedWaves.Add(wave);
		inactiveAmplifiedWaves.Remove(wave);

		return wave;
	}

	public GameObject GetStaticBomb()
	{
		if (inactiveStaticBombs.Count == 0)
		{
			GeneratePlayerBullets();
		}

		GameObject bomb = inactiveStaticBombs[inactiveStaticBombs.Count - 1];
		bomb.SetActive(true);
		activeStaticBombs.Add(bomb);
		inactiveStaticBombs.Remove(bomb);

		return bomb;
	}

	public GameObject GetEnemyBullet()
	{
		if (inactiveEnemyBullets.Count == 0)
		{
			GenerateEnemyBullets();
		}

		GameObject bullet = inactiveEnemyBullets[inactiveEnemyBullets.Count - 1];
		bullet.SetActive(true);
		activeEnemyBullets.Add(bullet);
		inactiveEnemyBullets.Remove(bullet);

		return bullet;
	}

	public GameObject GetBoss2Bullet()
    {
		if (inactiveBoss2Bullets.Count == 0)
        {
			GenerateBossBullets();
        }

		GameObject bullet = inactiveBoss2Bullets[inactiveBoss2Bullets.Count - 1];
		bullet.SetActive(true);
		activeBoss2Bullets.Add(bullet);
		inactiveBoss2Bullets.Remove(bullet);

		return bullet;
	}

	public void ReturnWaterBalloon(GameObject balloon)
	{
		inactiveWaterBalloons.Add(balloon);
		activeWaterBalloons.Remove(balloon);
	}

	public void ReturnStaticBomb(GameObject bomb)
	{
		inactiveStaticBombs.Add(bomb);
		activeStaticBombs.Remove(bomb);
	}

	public void ReturnAmplifiedWaves(GameObject wave)
	{
		inactiveAmplifiedWaves.Add(wave);
		activeAmplifiedWaves.Remove(wave);
	}

	public void ReturnEnemyBullet(GameObject bullet)
	{
		inactiveEnemyBullets.Add(bullet);
		activeEnemyBullets.Remove(bullet);
	}

	public void ReturnBoss2Bullet(GameObject bullet)
    {
		inactiveBoss2Bullets.Add(bullet);
		activeBoss2Bullets.Remove(bullet);
    }

	public List<GameObject> GetEnemyBullets()
	{
		return activeEnemyBullets;
	}
}