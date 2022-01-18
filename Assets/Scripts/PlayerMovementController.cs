using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float m_speed = 3f;
    public float r_speed = 3f;
    public float jumpForce = 2f;

    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();

        if (!animator)
            Debug.LogError("Animator not found");
        if (!rb)
            Debug.LogError("Rigidbody not found");
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

        if (direction.magnitude > 0.01)
        {
            transform.Rotate(new Vector3(0, horizontal, 0) * r_speed * Time.deltaTime, Space.World);
            transform.position = transform.position + vertical * transform.forward * Time.deltaTime * m_speed;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("IsGrounded", isGrounded);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        //Debug.Log(isGrounded);
    }
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;

    }
}
