using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        if (other.tag == "Player")
        {
            Time.timeScale = 0;
            GameObject.Find("Canvas").transform.Find("Clear").gameObject.SetActive(true);
        }
    }
}
