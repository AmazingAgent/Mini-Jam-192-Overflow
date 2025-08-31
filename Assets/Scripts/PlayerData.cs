using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    string scoreKey = "Score";
    public int CurrentScore { get; set; }


    [SerializeField] private GameObject textObj;
    private TMP_Text textMeshPro;

    [SerializeField] private int coins = 0;
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
        if (coins > PlayerPrefs.GetInt(scoreKey))
        {
            PlayerPrefs.SetInt(scoreKey, coins);
        }
    }
}
