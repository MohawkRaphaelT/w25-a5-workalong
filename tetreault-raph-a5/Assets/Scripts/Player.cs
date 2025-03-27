using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float thrust = 3;
    [SerializeField] private float rotationSpeed = 360;
    [SerializeField] private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per physics frame
    void FixedUpdate()
    {
        float rotationAngle = -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;    
        rb2d.MoveRotation(rotationAngle + transform.rotation.eulerAngles.z);

        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 thrustForce = transform.up * thrust;
            rb2d.AddForce(thrustForce);
        }
    }
}
