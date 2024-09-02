using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 targetPos;
    Vector3 myPos;
    Vector3 newPos;

    public float speed = 0.003f;

    void Start()
    {
        targetPos = GameObject.Find("Player").transform.position;
        myPos = transform.position;

        newPos = (targetPos - myPos) * speed;

        Destroy(gameObject, 5f);
    }
    void FixedUpdate()
    {
        transform.position = transform.position + newPos;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        if (other.tag == "Player")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if(playerHealth != null)
            {
                playerHealth.onDamage();
            }
        }
    }
}