using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBehavior : MonoBehaviour
{
    public GameObject barrier;
    public float duration;

    public void ActivateBarrier()
    {
        if (!barrier.activeSelf)
            StartCoroutine(StartBarrierDuration());
    }

    private IEnumerator StartBarrierDuration()
    {
        barrier.SetActive(true);
        yield return new WaitForSeconds(duration);
        barrier.SetActive(false);
    }
}
