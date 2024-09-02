using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;
    private float spawnRate;
    private float timeAfterSpawn;
    
    void Start()
    { 
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position , transform.rotation);
            
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
