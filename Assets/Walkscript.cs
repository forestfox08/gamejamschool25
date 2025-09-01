using UnityEngine;

public class Walkscript : MonoBehaviour
{
    public Rigidbody rb;
    public bool onGround = true;
    private CharacterController character;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // transform.position
    private void Update()
    {
        if (onGround)
            if (Input.GetKeyDown(KeyCode.Space))
            {
             
            }
        }
    }
