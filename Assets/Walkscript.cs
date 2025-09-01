using UnityEngine;

public class Walkscript : MonoBehaviour
{
    public Rigidbody rb;
    public bool onGround = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // transform.position
    void Update()
    {
        
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
             
            }
        }
    }
}
