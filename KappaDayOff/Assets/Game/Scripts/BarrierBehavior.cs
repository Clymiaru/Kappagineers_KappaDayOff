using System.Collections;
using UnityEngine;

public class BarrierBehavior : MonoBehaviour
{
	public  GameObject barrier;
	public  float      duration;
	private bool       activatable = true;
	private float      cooldown;

	private void Awake()
	{
		cooldown = GameManager.Instance.PlayerCharacter.BarrierCooldownTime;
	}

	public void ActivateBarrier()
	{
		if (activatable)
		{
			StartCoroutine(StartBarrierDuration());
			StartCoroutine(StartBarrierCD());
		}
	}

	private IEnumerator StartBarrierDuration()
	{
		barrier.SetActive(true);
		yield return new WaitForSeconds(duration);
		barrier.SetActive(false);
	}

	private IEnumerator StartBarrierCD()
	{
		activatable = false;
		yield return new WaitForSeconds(cooldown);
		activatable = true;
	}
}