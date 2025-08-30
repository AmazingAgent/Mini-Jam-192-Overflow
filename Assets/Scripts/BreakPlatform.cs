using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "platform" || other.gameObject.tag == "rock")
        {
            gameObject.transform.parent.GetComponent<ScrollingMovement>().KillPlayer();
            Destroy(gameObject);
        }
    }

    
        
}
