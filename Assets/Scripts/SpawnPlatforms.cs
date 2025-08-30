using System;
using Unity.Mathematics;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private float spawnrate = 5f;
    [SerializeField] private float spawnVar = 1f;
    [SerializeField] private float timer;
    void Start()
    {
        timer = 0f;
    }

    
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            GameObject newPlatform = Instantiate(platform);
            newPlatform.transform.position = new Vector3 (transform.position.x + UnityEngine.Random.Range(-5f, 5f), -0.5f, 12f);
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        timer = spawnrate + UnityEngine.Random.Range(-spawnVar, spawnVar);
    }
}
