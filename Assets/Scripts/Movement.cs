using UnityEditor.Toolbars;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] GameObject GroundCheck;
    bool grounded;
    float horizontalInput;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        rb.linearVelocityX = horizontalInput * speed;
        if (Input.GetKeyUp(KeyCode.Space))
            {
            rb.linearVelocityY = jumpForce;
            }
       

    }
}
