using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f; // Speed of paddle movement

    // Check if the paddle belongs to the Player A
    // We're using the same script for both the player A & B.
    public bool isPlayerA;

    private float movement; // Records the direction and movement speed of the paddle.

    void Update()
    {
        // If this paddle belongs to the player B
        if (isPlayerA)
        {
            // Get the input for the player A (W to move up, S to move down)
            float inputY = Input.GetKey(KeyCode.W) ? 1f : Input.GetKey(KeyCode.S) ? -1f : 0f;
            movement = inputY * speed * Time.deltaTime; // Calculate movement with speed and deltaTime for smooth movement
        }
        else
        {
            // If it�s the player B' paddle, use arrow keys (UpArrow to move up, DownArrow to move down)
            float inputY = Input.GetKey(KeyCode.UpArrow) ? 1f : Input.GetKey(KeyCode.DownArrow) ? -1f : 0f;
            movement = inputY * speed * Time.deltaTime; // Apply the movement calculation
        }

        // Apply the calculated movement to the paddle's position
        transform.Translate(0, movement, 0);

        // Clamp/Limit the paddle within the vertical bounds of the screen (to prevent moving off-screen)
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -3.5f, 3.5f); // Adjust the minimum and maximum bounds as needed
        transform.position = pos; // Update the paddle's position
    }
}
