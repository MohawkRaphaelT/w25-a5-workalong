using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello, World!");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.DownArrow))
            movement += Vector3.down;

        if (Input.GetKey(KeyCode.UpArrow))
            movement += Vector3.up;

        if (Input.GetKey(KeyCode.LeftArrow))
            movement += Vector3.left;

        if (Input.GetKey(KeyCode.RightArrow))
            movement += Vector3.right;

        // Add movement to player scaled by time
        transform.position += movement * Time.deltaTime * speed;
    }
}
