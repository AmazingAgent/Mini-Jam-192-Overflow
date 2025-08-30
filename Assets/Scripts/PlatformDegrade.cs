using UnityEngine;

public class PlatformDegrade : MonoBehaviour
{
    private ScrollingMovement parentObj;
    [SerializeField] float fallHealth = 0f;
    void Start()
    {
        parentObj = gameObject.transform.parent.parent.GetComponent<ScrollingMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parentObj.health < fallHealth)
        {
            transform.position = new Vector3(transform.position.x, -5f, transform.position.z);
        }
    }
}
