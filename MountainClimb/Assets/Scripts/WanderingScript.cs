using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingScript : MonoBehaviour
{
    private Rigidbody rb;

    public int speed = 40;
    public float turnTimer = 4f;
    public bool rotateOn = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        StartCoroutine(Movement());
    }

    void Update()
    {
        if (rotateOn == false)
        {
            rb.MovePosition(transform.position + (Vector3.right * Time.deltaTime * speed));
        }
    }

    IEnumerator Movement()
    {
        while (true)
        {
            yield return new WaitForSeconds(turnTimer);
            transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
        }
    }
}
