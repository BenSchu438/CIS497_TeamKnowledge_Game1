using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;

    private void FollowTarget()
    {
        //find location to put camera
        Vector3 pos = new Vector3(
            player.position.x + offset.x, 
            player.position.y + offset.y, 
            player.position.z + offset.z);

        //Minimum so camera doesnt clip through ground
        if (pos.y <= 1.5)
            pos.y = 1.5f;

        //set position
        transform.position = Vector3.Lerp(transform.position, pos, followSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowTarget();
    }
}
