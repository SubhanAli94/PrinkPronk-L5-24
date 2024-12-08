using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f; // Speed of paddle movement

    void Update()
    {
        float movement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, movement, 0);

        // Clamp paddle within screen bounds
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -3.5f, 3.5f); // Adjust bounds as needed
        transform.position = pos;
    }
}
