using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierRange : MonoBehaviour
{
    public ParticleSystem barrier;
    public GameObject Barrier;

    private void Update()
    {
        if (Barrier.activeSelf == true)
        {
            StartCoroutine(BarrierStop());
        }
    }

    public void BarrierStart()
    {
        Barrier.SetActive(true);
        barrier.Play();
    }

    IEnumerator BarrierStop()
    {
        yield return new WaitForSeconds(5);
        barrier.Stop();
        Barrier.SetActive(false);
    }
}
