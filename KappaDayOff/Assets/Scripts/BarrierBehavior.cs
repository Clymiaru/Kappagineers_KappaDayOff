using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBehavior : MonoBehaviour
{
    public GameObject barrier;
    public float duration;
    public bool isBarrierActive = false;

    public void ActivateBarrier()
    {
        StartCoroutine(StartBarrierDuration());
    }

    private IEnumerator StartBarrierDuration()
    {
        barrier.SetActive(true);
        isBarrierActive = true;
        yield return new WaitForSeconds(duration);
        barrier.SetActive(false);
        isBarrierActive = false;
    }
}
