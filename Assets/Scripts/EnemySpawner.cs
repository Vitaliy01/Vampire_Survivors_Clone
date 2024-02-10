using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public float timeToSpawn;
    private float spawnCounter;

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if(spawnCounter <= 0)
        {
            spawnCounter = timeToSpawn;

            Instantiate(enemyToSpawn, transform.position, transform.rotation);
        }
    }
}
