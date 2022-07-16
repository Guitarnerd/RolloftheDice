using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;
    private float xInput;
    private float zInput;
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
        
        
    }

    void FixedUpdate()
    {
        Move();

    }

    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Jump();    
        // }
        
        
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }

    // void Jump()
    // {
    //     velocity = jumpForce;
    //     transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    // }
}
