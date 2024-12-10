using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f; // Speed of paddle movement

    // Check if the paddle belongs to the Player A
    // We're using the same script for both the player A & B.
    public bool isPlayerA;

    private float movement; // Records the direction and movement speed of the paddle.

    public InputAction playerInputAction; //To Detect the input action


    //Called every time the GameObject is enabled in the scene.
    private void OnEnable()
    {
        playerInputAction.Enable();
    }

    //Called every time the GameObject is disabled in the scene.
    private void OnDisable()
    {
        playerInputAction.Disable();
    }

    void Update()
    {
        // Get the input for the player
        // And Multiply it with speed and deltaTime for smooth movement
        movement = playerInputAction.ReadValue<Vector2>().y * speed * Time.deltaTime;

        // Apply the calculated movement to the paddle's position
        transform.Translate(0, movement, 0);

        // Clamp/Limit the paddle within the vertical bounds of the screen (to prevent moving off-screen)
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -3.5f, 3.5f); // Adjust the minimum and maximum bounds as needed
        transform.position = pos; // Update the paddle's position
    }
}
