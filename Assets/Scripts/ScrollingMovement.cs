using UnityEngine;

public class ScrollingMovement : MonoBehaviour
{
    [SerializeField] private float ScrollSpeed = 1f;
    private bool following = false;
    private GameObject player;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && following)
        {
            following = false;
            player.GetComponent<FollowScript>().RemoveFollowing();
        }



        if (following) {
            rb.linearVelocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        }
        else {
            rb.linearVelocity = new Vector3(0, 0, -ScrollSpeed);
        }


        if (transform.position.z < -12f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Player")
        {
            if (other.transform.position.y > 0.75f)
            {
                player = other.gameObject;
                //print("entered");
                if (!player.GetComponent<FollowScript>().GetFollowing()) {
                    player.GetComponent<FollowScript>().SetFollowing(this.gameObject);
                    following = true;
                    player.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
                }

                
            }
        }
    }
}
