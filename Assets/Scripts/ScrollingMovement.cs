using UnityEngine;

public class ScrollingMovement : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    public bool following = false;
    private GameObject player;
    private Rigidbody rb;

    // platform health
    [SerializeField] public bool starterPlatform = false;
    [SerializeField] public float health = 8f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // randomize starting health
        if (!starterPlatform) { health = Random.Range(1.9f, health); }
        

    }

    // Update is called once per frame
    void Update()
    {
        // Lower health
        if (following)
        {
            health -= Time.deltaTime;
            if (health < 0f) { KillPlayer(); }
        }

        // Makes player jump
        if (Input.GetKeyDown(KeyCode.Space) && following)
        {
            following = false;
            player.GetComponent<FollowScript>().RemoveFollowing();
        }


        // Locks platform to player
        if (following) {
            rb.linearVelocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        }
        else {
            rb.linearVelocity = new Vector3(0, 0, -scrollSpeed);
        }

        // Despawns object
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

    public void KillPlayer()
    {
        if (following)
        {
            player.GetComponent<PlayerController>().KillPlayer();
            Destroy(this.gameObject);
        }
    }
}
