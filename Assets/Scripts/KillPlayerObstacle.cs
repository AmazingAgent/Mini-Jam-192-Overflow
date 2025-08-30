using UnityEngine;

public class KillPlayerObstacle : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            other.GetComponent<PlayerController>().KillPlayer();
        }
    }
}
