using UnityEngine;

public class PlayerData : MonoBehaviour
{

    [SerializeField] private float coins = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }
}
