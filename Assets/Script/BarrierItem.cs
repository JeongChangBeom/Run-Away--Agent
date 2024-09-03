using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierItem : MonoBehaviour
{
    BarrierRange barrier;
    private void Start()
    {
        barrier = GameObject.Find("Player").transform.Find("barrierRange").gameObject.GetComponent<BarrierRange>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SoundManager.instance.Barrier_Play();

            barrier.BarrierStart();

            Destroy(gameObject);
        }
    }
}
