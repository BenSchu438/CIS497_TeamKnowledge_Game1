using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingScript : MonoBehaviour
{
    private Rigidbody rb;

    public int speed = 40;
    public float turnTimer = 4f;
    public bool rotateOn = false;
    public int direction = 0;
    

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
            rb.MovePosition(transform.position + (new Vector3(Mathf.Cos(direction), 0, Mathf.Sin(direction)) * Time.deltaTime * speed));
        }
    }

    IEnumerator Movement()
    {
        while (true)
        {
            direction = Random.Range(-180, 180);
            transform.Rotate(new Vector3(0, direction, 0));
            yield return new WaitForSeconds(turnTimer);
        }
    }
}
