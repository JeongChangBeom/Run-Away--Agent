using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    AudioSource healSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            healSound = GetComponent<AudioSource>();
            healSound.Play();

            transform.position = new Vector3(1200, 1200, 1200);
            Invoke("Destroyitem", 5);

            PlayerHealth playerhealth = other.GetComponent<PlayerHealth>();
            if (playerhealth.Health >= 5)
            {
                return;
            }
            else
            {
                playerhealth.Health++;
            }
        }
    }
    public void Destroyitem()
    {
        Destroy(gameObject);
    }
}
