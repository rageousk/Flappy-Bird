using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Piranha")
        {

            // Destroy the arrow itself
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Pipe") // Example for handling collisions with other objects
        {
            Destroy(gameObject); // Destroy the arrow if it hits a wall or obstacle
        }
    }
}
