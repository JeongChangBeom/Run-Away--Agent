using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SoundManager.instance.Heal_Play();

            PlayerHealth playerhealth = other.GetComponent<PlayerHealth>();

            if (playerhealth.Health < 5)
            {
                playerhealth.Health++;
            }

            Destroy(gameObject);
        }
    }
}
