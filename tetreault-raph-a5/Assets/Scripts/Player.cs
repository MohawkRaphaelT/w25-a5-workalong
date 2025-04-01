using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float thrust = 3;
    [SerializeField] private float rotationSpeed = 360;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private int lives = 3;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 3;


    private void Update()
    {
        int leftClickID = 0;
        if (Input.GetMouseButtonDown(leftClickID))
        {
            // Bullet inital position
            Vector3 pos = transform.position + transform.up;
            Quaternion rot = Quaternion.identity;

            // Create a clone of bullet object
            GameObject bullet = Instantiate(bulletPrefab, pos, rot);
            Rigidbody2D bulletRB2D = bullet.GetComponent<Rigidbody2D>();

            // Shoot bullet in facing direction
            Vector2 force = transform.up * bulletSpeed;
            bulletRB2D.AddForce(force, ForceMode2D.Impulse);
        }
    }

    // Update is called once per physics frame
    void FixedUpdate()
    {
        // Forcibly rotate player when using left-right inputs
        float rotationAngle = -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;    
        rb2d.MoveRotation(rotationAngle + transform.rotation.eulerAngles.z);

        // Add force to player
        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 thrustForce = transform.up * thrust;
            rb2d.AddForce(thrustForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        //Asteroid asteroid = collider2D.GetComponent<Asteroid>();
        //if (asteroid == null)
        //    return;

        bool isAsteroid = collider2D.gameObject.CompareTag("Asteroid");
        if (!isAsteroid)
            return;

        lives--;
        if (lives == 0)
        {
            // do something
        }

        // Reset player position
        rb2d.MovePosition(Vector2.zero);

        // Reset asteroids...
    }
}
