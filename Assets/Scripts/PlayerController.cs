using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Vector3 velocity = new Vector3(0, 0, 0);
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float jumpStrength = 2f;
    private Rigidbody rb;

    private bool movingUp = false;
    private bool movingSide = false;

    private FollowScript followScript;
    public  bool following = false;

    // Death state
    public bool dead = false;

    // Animation
    [SerializeField] private GameObject spriteObj;
    private Animator animator;

    void Start()
    {
        animator = spriteObj.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        followScript = gameObject.GetComponent<FollowScript>();
        acceleration = 1f * acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead) {
            movingUp = false;
            movingSide = false;

            if (Input.GetKey(KeyCode.A))
            {
                movingSide = true;
                velocity.x -= acceleration * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movingSide = true;
                velocity.x += acceleration * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.W))
            {
                movingUp = true;
                velocity.z += acceleration * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movingUp = true;
                velocity.z -= acceleration * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Space) && following)
            {
                following = false;
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpStrength, rb.linearVelocity.z);
            }




            if (!movingSide)
            {
                if (Mathf.Abs(velocity.x) >= 0.3f) { velocity.x -= acceleration * 1.2f * Time.deltaTime * (velocity.x / Mathf.Abs(velocity.x)); }
                else { velocity.x = 0f; }
            }
            if (!movingUp)
            {
                if (Mathf.Abs(velocity.z) >= 0.3f) { velocity.z -= acceleration * 1.2f * Time.deltaTime * (velocity.z / Mathf.Abs(velocity.z)); }
                else { velocity.z = 0f; }
            }


            if (movingUp && movingSide)
            {
                if (following)
                {
                    velocity.x = Mathf.Clamp(velocity.x, (-maxSpeed + 2f) / 1.4f, (maxSpeed - 2f) / 1.4f);
                    velocity.z = Mathf.Clamp(velocity.z, (-maxSpeed - 3f) / 1.4f, (maxSpeed - 3f) / 1.4f);
                }
                else
                {
                    velocity.x = Mathf.Clamp(velocity.x, -maxSpeed / 1.4f, maxSpeed / 1.4f);
                    velocity.z = Mathf.Clamp(velocity.z, -maxSpeed / 1.4f, maxSpeed / 1.4f);
                }
            }
            else
            {
                if (following)
                {
                    velocity.x = Mathf.Clamp(velocity.x, (-maxSpeed) + 2f, (maxSpeed) - 2f);
                    velocity.z = Mathf.Clamp(velocity.z, (-maxSpeed) - 3f, (maxSpeed) - 3f);
                }
                else
                {
                    velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
                    velocity.z = Mathf.Clamp(velocity.z, -maxSpeed, maxSpeed);
                }
            }

            UpdateVelocity(velocity);
        }

        // Player is dead
        else
        {
            if (transform.position.y < -1)
            {
                Destroy(this.gameObject);
            }
        }

        UpdateAnimator();


    }

    void UpdateVelocity(Vector3 vel)
    {
        vel.y = rb.linearVelocity.y;
        rb.linearVelocity = vel;
    }

    public void KillPlayer()
    {
        dead = true;
        rb.linearVelocity = new Vector3(0, jumpStrength, 0);
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }


    private void UpdateAnimator()
    {
        if (!dead) // Normal animations
        {
            if (velocity.z != 0) // Moving vertically
            {
                if (velocity.z > 0) { animator.SetInteger("Direction", 0); } // up
                else { animator.SetInteger("Direction", 1); } // down
            }
            else // Moving horizontally
            {
                if (velocity.x != 0)
                {
                    if (velocity.x > 0) { animator.SetInteger("Direction", 2); } // right
                    else { animator.SetInteger("Direction", 3); } // left
                }
                else { animator.SetInteger("Direction", 0); }
            }
            

            // Update jump logic
            if (following) { animator.SetBool("Jumping", false); }
            else { animator.SetBool("Jumping", true); }
            
        }
        else
        {
            animator.SetInteger("Direction", -1);
            animator.SetBool("Dead", true);
        }
    }
}
