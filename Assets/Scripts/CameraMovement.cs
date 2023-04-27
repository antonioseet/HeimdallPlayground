using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10.0f; // The speed at which the camera will move


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // Move the camera forward
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Move the camera backward
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Move the camera to the left
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Move the camera to the right
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            // Move the camera up
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            // Move the camera down
            transform.position += Vector3.down * speed * Time.deltaTime;
        }


    }

}

