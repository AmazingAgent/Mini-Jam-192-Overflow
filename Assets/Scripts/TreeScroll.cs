using UnityEngine;

public class TreeScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    [SerializeField] private float loopPos = 10f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - scrollSpeed * Time.deltaTime);
        if (transform.position.z < -loopPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2 * loopPos);
        }
    }
}
