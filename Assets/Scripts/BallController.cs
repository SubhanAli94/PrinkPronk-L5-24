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
        // Check collision with walls

        if (collision.gameObject.CompareTag("PlayerAWall")) //Player A's Wall
        {
            //Add Score to the Player B's account
            GameManager.instance.AddScoreToPlayerBAccount();
        }
        else if (collision.gameObject.CompareTag("PlayerBWall")) //Player B' Wall
        {
            //Add Score to the Opposing Player A's account
            GameManager.instance.AddScoreToPlayerAAccount();
        }
    }
}
