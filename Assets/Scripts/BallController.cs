using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f; // Initial speed of the ball
    private Rigidbody2D rb; //Ball's Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Set ball's Rigidbody
        LaunchBall();
    }

    void LaunchBall()
    {
        // Launch ball in a random initial direction
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(x, y).normalized;
        rb.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if collision is with a paddle
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Reverse X direction and preserve speed
            Vector2 velocity = rb.velocity;
            velocity.x = -velocity.x; // Reverse horizontal direction

            // Add a slight random variation to the Y velocity for unpredictability
            velocity.y += Random.Range(-0.5f, 0.5f);

            // Normalize velocity to maintain constant speed
            rb.velocity = velocity.normalized * speed;
        }
    }
}
