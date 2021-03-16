using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    public float horizontalInput;
    public float verticalInput;
    public float speed = 100.0f;
    public float maxSpeed;
    public float fallSpeedMultiplier = 1.5f;

    public bool grounded;
    public bool walking;
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
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
            animator.SetBool("walking", true);
            walking = true;
        } else
        {
            animator.SetBool("walking", false);
            walking = false;
        }

        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;

        // Make player fall faster when in air
        if(!grounded)
        {
            Vector3 temp;

            // checks to make sure player will always go downwards instead of flying into orbit
            if (rb.velocity.y > 0)
            {
                temp = new Vector3(rb.velocity.x, (float)(rb.velocity.y * -1 * fallSpeedMultiplier), rb.velocity.z);
            }
            else
            {
                temp = new Vector3(rb.velocity.x, (float)(rb.velocity.y * fallSpeedMultiplier), rb.velocity.z);
            }

            rb.velocity = temp;
        }
        

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("grounded", true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            animator.SetBool("grounded", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("grounded", true);
        }
    }
}
