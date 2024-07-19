/*// NOTE: If the box above this text note says anything
// other than Assembly-CSharp, autofill will NOT work.
// Unity functions and syntax can be tedious, and it is
// common to make mistakes in commands when there is no guide.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    // Boolean: is the player touching this object?
  //  bool isArrowTouching;

    void Awake()
    {
        // Initialize the boolean
      // isArrowTouching = false;
    }

    // The following functions work with the collision
    // of another gameobjects collider.

    // OnCollisionEnter is called once a collider
    // of another object starts touching this object's collider.
    void OnCollisionEnter2D(Collision2D other)
    {
        // collision.gameobject.tag calls the tag property of the 
        // other objects collider that has touched this object's collider

        // With logic compare the collision's tag with the tag of the
        // player Square to see if the Player is the obejct that touched this one.
        if (other.gameObject.tag == "Piranha")
        {
            // Print for Debugging
            Debug.Log("Touched the Piranha");

            Destroy(other.gameObject); // Destroy the Piranha
            Destroy(gameObject); // Destroy the arrow itself
            // the arrow has touched the Piranha
           // isArrowTouching = false;
        }

        else if (other.gameObject.tag == "Pipe") // Example for handling collisions with other objects
        {
            Destroy(gameObject); // Destroy the arrow if it hits a wall or obstacle
          //  isArrowTouching = false;
        }
        
    
    }
} */