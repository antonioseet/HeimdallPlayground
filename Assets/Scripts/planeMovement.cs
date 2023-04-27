using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeMovement : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float rotateSpeed = 10.0f;

    void Update()
    {
        // Move the triangle
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(xInput, 0, zInput) * moveSpeed);

        // Rotate the triangle
        if (Input.GetKey(KeyCode.I))
        {
            transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.O))
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.P))
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }
    }
}
