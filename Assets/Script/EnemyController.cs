using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float spawnRateMin;
    public float spawnRateMax;
    private float spawnRate;
    private float timeAfterSpawn;

    private Transform target;
    
    void Start()
    {
        target = GameObject.FindWithTag("Player").gameObject.transform;

        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    
    void Update()
    {
        TargetRotaion();

        BulletSpawn();
    }

    void TargetRotaion()
    {
        Vector3 dir = target.transform.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void BulletSpawn()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
