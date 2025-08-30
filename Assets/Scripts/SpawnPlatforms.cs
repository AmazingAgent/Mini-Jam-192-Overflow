using System;
using Unity.Mathematics;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject rock;
    [SerializeField] private float spawnrate = 5f;
    [SerializeField] private float spawnVar = 1f;
    [SerializeField] private float timer;

    // whether or not there will be an obstacle
    private bool spawnObstacle = false;
    private float obstacleTimer = 0f;
    private GameObject nextObstacle;
    void Start()
    {
        timer = 0f;
    }

    
    void Update()
    {
        timer -= Time.deltaTime;

        if (spawnObstacle) // spawn obstacle
        {
            obstacleTimer -= Time.deltaTime;
            if (obstacleTimer <= 0)
            {
                GameObject newObstacle = Instantiate(nextObstacle);
                newObstacle.transform.position = new Vector3(transform.position.x + UnityEngine.Random.Range(-5f, 5f), -0.5f, 12f);
                spawnObstacle = false;
            }
        }
        else // no obstacle
        {
            if (timer <= 0)
            {
                GameObject newPlatform = Instantiate(platform);
                newPlatform.transform.position = new Vector3(transform.position.x + UnityEngine.Random.Range(-5f, 5f), -0.5f, 12f);
                UpdateTimer();
            }
        }
    }

    void UpdateTimer()
    {
        timer = spawnrate + UnityEngine.Random.Range(-spawnVar, spawnVar);

        if (UnityEngine.Random.Range(0,2) == 1) // spawn obstacle
        {
            spawnObstacle = true;
            obstacleTimer = timer / 2f;

            switch (UnityEngine.Random.Range(0, 1)) // picks random obstacle
            {
                case 0:
                    nextObstacle = rock;
                    break;
            }
        }
        
    }
}
