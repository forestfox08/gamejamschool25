using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    [Header("Double Jump")]
    public int maxJumps = 2;
    private int currentJumps;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody2D attached to " + gameObject.name);
        }

        if (groundCheck == null)
        {
            Debug.LogError("groundCheck is not assigned on " + gameObject.name);
        }
    }

    void Update()
    {
        // Horizontal input
        moveInput = Input.GetAxisRaw("Horizontal");

        // Ground check
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Reset jumps wanneer speler landt
        if (isGrounded && !wasGrounded)
        {
            currentJumps = 0;
        }

        // Jump input
        if (Input.GetButtonDown("Jump") && currentJumps < maxJumps)
        {
            Jump();
            currentJumps++; // Tel de sprongen
        }
    }

    void FixedUpdate()
    {
        // Horizontal movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        Debug.Log("Jump nr: " + (currentJumps + 1));
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
