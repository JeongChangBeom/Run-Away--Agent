using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Player")
        {
            SoundManager.instance.Destroy_Play();

            GameObject.Find("Canvas").transform.Find("DestroyImage").gameObject.SetActive(true);
            GameObject.Find("DestroyParent").transform.Find("DestroyRange").gameObject.SetActive(true);

            Destroy(gameObject);
        }
    }
}
