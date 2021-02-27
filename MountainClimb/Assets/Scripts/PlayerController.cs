using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    public float horizontalInput;
    public float verticalInput;
    public float speed = 100.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        if (horizontalInput != 0 || verticalInput != 0)
        {
            rb.MovePosition(transform.position + (movement * Time.deltaTime * speed));
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
}
