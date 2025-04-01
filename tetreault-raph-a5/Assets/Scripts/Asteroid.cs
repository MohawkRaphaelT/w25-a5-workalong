using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minForce = 1;
    public float maxForce = 5;

    void Start()
    {
        Rigidbody2D rb2d = this.GetComponent<Rigidbody2D>();

        float randomAngle = Random.Range(0, Mathf.PI * 2);
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        Vector2 force = direction * Random.Range(minForce, maxForce);

        rb2d.AddForce(force, ForceMode2D.Impulse);
    }

}
