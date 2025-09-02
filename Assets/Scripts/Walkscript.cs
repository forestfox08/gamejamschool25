using UnityEngine;

public class Walkscript : MonoBehaviour
{
    public Rigidbody rb;
    public bool onGround = true;
    public float moveSpeed = 3f;
    public float jumpForce = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += -transform.forward * moveSpeed * Time.deltaTime;
        }
        if (onGround)
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, 0, 0) * jumpForce * Time.deltaTime);
                onGround = false;
            }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 0, 0) * jumpForce * Time.deltaTime);
            onGround = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
}