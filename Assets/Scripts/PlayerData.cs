using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    [SerializeField] private GameObject textObj;
    private TMP_Text textMeshPro;

    [SerializeField] private float coins = 0f;
    void Start()
    {
        textMeshPro = textObj.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoins();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    private void UpdateCoins()
    {
        textMeshPro.text = coins.ToString();
    }
}
