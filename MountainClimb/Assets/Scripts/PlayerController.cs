using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    public float horizontalInput;
    public float verticalInput;
    public float speed = 100.0f;
    public float fallSpeed = -10;

    public bool grounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        if ((horizontalInput != 0 || verticalInput != 0) && grounded)
        {
            //rb.MovePosition(transform.position + (movement * Time.deltaTime * speed));

            rb.AddForce(transform.forward * speed, ForceMode.Force);

            transform.rotation = Quaternion.LookRotation(movement);
        }
        else if (horizontalInput == 0 && verticalInput == 0 && grounded)
            rb.velocity = new Vector3(0, 0, 0);
        if(!grounded)
        {
            rb.velocity = new Vector3(0, fallSpeed, 0);
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }
}
