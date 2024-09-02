using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierItem : MonoBehaviour
{
    AudioSource BarrierSound;
    BarrierRange barrier;
    private void Start()
    {
        barrier = GameObject.Find("Player").transform.Find("barrierRange").gameObject.GetComponent<BarrierRange>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            BarrierSound = GetComponent<AudioSource>();
            BarrierSound.Play();

            barrier.BarrierStart();
            transform.position = new Vector3(1100, 1100, 1100);
            Invoke("Destroyitem", 5.5f);
        }
    }
    public void Destroyitem()
    {
        Destroy(gameObject);
    }
}
