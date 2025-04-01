using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minSpeed = 1;
    public float maxSpeed = 5;

    void Start()
    {
        Rigidbody2D rb2d = this.GetComponent<Rigidbody2D>();

        // Create random point on unit circle
        float randomAngle = Random.Range(0, Mathf.PI * 2);
        Vector2 direction = new(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        // Create force vector
        float speed = Random.Range(minSpeed, maxSpeed);
        Vector2 force = direction * speed;

        // Apply force all at once (impulse)
        rb2d.AddForce(force, ForceMode2D.Impulse);
    }

}
