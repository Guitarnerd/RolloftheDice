using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;
    public GameObject diceCenter;

    public bool isGrounded;
    private float xInput;
    private float zInput;
    private SphereCollider groundCheck;
    public float jumpForce = 10f;
    private float velocity;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);   
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
        Debug.Log("is Grounded");
    }

}
