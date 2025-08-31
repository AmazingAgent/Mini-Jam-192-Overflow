using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Destroy(this.gameObject);
        }
    }
}
