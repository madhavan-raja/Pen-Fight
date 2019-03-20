using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfiner : MonoBehaviour
{
    public float minHeight = -1;
    public float maxHeight = 2;
    public float xLimit = 2;
    public float zLimit = 2;

    void Update()
    {
        if (Input.GetButton("Fly"))
        {
            if (transform.position.y < minHeight)
                transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
            else if (transform.position.y > maxHeight)
                transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);

            if (transform.position.x < -xLimit)
                transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
            else if (transform.position.x > xLimit)
                transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);

            if (transform.position.z < -zLimit)
                transform.position = new Vector3(transform.position.x, transform.position.y, -zLimit);
            else if (transform.position.z > zLimit)
                transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
        }
    }
}
