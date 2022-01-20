using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float m_speed = 3f;
    public float r_speed = 3f;
    public float jumpForce = 2f;

    private Animator animator;
    private Rigidbody rb;
    private AudioSource walk;
    private bool isGrounded = true;
    private bool playSound = false;
    private bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        walk = gameObject.GetComponent<AudioSource>();

        if (!animator)
            Debug.LogError("Animator not found");
        if (!rb)
            Debug.LogError("Rigidbody not found");
        if (!walk)
            Debug.LogError("Sound not found");
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetBool("IsGrounded", isGrounded);

        if (direction.magnitude > 0.01) //move
        {
            playSound = true;
            transform.Rotate(new Vector3(0f, horizontal, 0f) * r_speed * Time.deltaTime, Space.World);
            transform.position = transform.position + vertical * transform.forward * Time.deltaTime * m_speed;
            if (playSound && !isPlaying && isGrounded)
            {
                walk.Play();
                isPlaying = true;
            }
        }
        else
        {
            walk.Stop();
            isPlaying = false;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded) //Jump
        {
            animator.SetBool("IsGrounded", isGrounded);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            walk.Stop();
            isPlaying = false;
        }
        if (transform.position.y < -1) //in case the player falls
            transform.position = new Vector3(transform.position.x, 2, transform.position.z);

    }
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }
}
