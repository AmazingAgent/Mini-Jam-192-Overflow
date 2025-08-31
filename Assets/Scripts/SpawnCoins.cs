using UnityEngine;

public class SpawnCoins : MonoBehaviour
{

    [SerializeField] private GameObject coin;
    [SerializeField] private float spawnrate = 5f;
    [SerializeField] private float spawnVar = 1f;
    [SerializeField] private float timer;

    private float coinSpread = 1.5f;

    void Start()
    {
        timer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (UnityEngine.Random.Range(0, 2) == 1) // spawn coin row
            {
                GameObject coinObj1 = Instantiate(coin);
                GameObject coinObj2 = Instantiate(coin);
                GameObject coinObj3 = Instantiate(coin);
                float spawnX = UnityEngine.Random.Range(-3f, 3f);
                coinObj1.transform.position = new Vector3(transform.position.x + spawnX, 1, 12f - coinSpread);
                coinObj2.transform.position = new Vector3(transform.position.x + spawnX, 1, 12f);
                coinObj3.transform.position = new Vector3(transform.position.x + spawnX, 1, 12f + coinSpread);
                UpdateTimer();
            }
            else // spawn single coin
            {
                GameObject coinObj = Instantiate(coin);
                coinObj.transform.position = new Vector3(transform.position.x + UnityEngine.Random.Range(-3f, 3f), 1, 12f);
                UpdateTimer();
            }
        }
        



    }


    void UpdateTimer()
    {
        timer = spawnrate + UnityEngine.Random.Range(-spawnVar, spawnVar);

        

    }

}
