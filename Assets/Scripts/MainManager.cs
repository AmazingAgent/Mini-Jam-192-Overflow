using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    string scoreKey = "Score";
    public int CurrentScore {  get;  set; }

    [SerializeField] private GameObject textObj;
    private TMP_Text textMeshPro;

    [SerializeField] private bool resetStats = false;

    void Start()
    {
        textMeshPro = textObj.GetComponent<TMP_Text>();
        textMeshPro.text = "High Score: " + CurrentScore.ToString();
    }

    private void Awake()
    {
        if (resetStats) { PlayerPrefs.SetInt(scoreKey, 0); }
        CurrentScore = PlayerPrefs.GetInt(scoreKey);
    }


}
