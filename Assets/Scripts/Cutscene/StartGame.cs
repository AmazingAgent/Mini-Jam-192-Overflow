using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    // ID = 1: River
    // ID = 2: Player
    [SerializeField] private int cutsceneID;
    private bool sceneStarted = false;

    [SerializeField] private float moveSpeed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cutsceneID == 1) // River
        {
            if (!sceneStarted)
            {
                if (Input.GetKeyDown(KeyCode.Space)) // Start cutscene
                {
                    sceneStarted = true;
                }
            }
            else // Playing cutscene
            {
                if (transform.position.z < 1.2f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (moveSpeed * Time.deltaTime));
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, 1.2f);
                    SceneManager.LoadScene("RunningScene1");
                }
            }
        }

        if (cutsceneID == 2) // Player
        {
            if (!sceneStarted)
            {
                if (Input.GetKeyDown(KeyCode.Space)) // Start cutscene
                {
                    sceneStarted = true;
                }
            }
            else // Playing cutscene
            {
                if (transform.position.y < 8f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, 8f, transform.position.z);
                }
            }
        }

    }
}
