using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    AudioSource destroySound;

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Player")
        {
            destroySound = GetComponent<AudioSource>();
            destroySound.Play();
            GameObject.Find("Canvas").transform.Find("DestroyImage").gameObject.SetActive(true);
            GameObject.Find("DestroyParent").transform.Find("DestroyRange").gameObject.SetActive(true);

            transform.position = new Vector3(1000, 1000, 1000);
            Invoke("Destroyitem", 5);
        }
    }
    public void Destroyitem()
    {
        Destroy(gameObject);
    }
}
