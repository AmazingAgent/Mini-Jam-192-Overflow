using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;

    private bool coinCollected = false;
    private float heightMax;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (coinCollected)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (4*Time.deltaTime), transform.position.z);
            if (transform.position.y > heightMax) { Destroy(this.gameObject); }
        }
    }

    public void SetValue(int value)
    {
        coinValue = value;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            other.GetComponent<PlayerData>().AddCoins(1);
            
            transform.position = other.transform.position;
            coinCollected = true;
            heightMax = transform.position.y + 1f;
        }
    }
}
