using UnityEngine;

public class ObstacleScroll : MonoBehaviour
{

    [SerializeField] private float scrollSpeed = 1f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(0, 0, -scrollSpeed);

        if (transform.position.z < -12f)
        {
            Destroy(this.gameObject);
        }
    }
}
