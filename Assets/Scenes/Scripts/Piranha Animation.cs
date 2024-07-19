using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaAnimation : MonoBehaviour
{
    public SpriteRenderer mouthOpenSprite;
    public SpriteRenderer mouthClosedSprite;
    public bool isMouthOpen = true;

    // Movement variables
    public float moveSpeed = 2f;
    public float upLimit;  // Inspector-adjustable maximum upward position
    public float downLimit; // Inspector-adjustable maximum downward position
    private bool isMovingUp = false; // Flag to track movement direction
    public bool isPiranhaAlive = true; 

    // Animation variables
    public float animationDelay = 0.2f; // Delay between open and closed mouth (seconds)
    private float timer = 0f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
     }
            void Update()
    {
        // Update animation timer
        timer += Time.deltaTime;

        // Check for animation switch based on timer and delay
        if (timer >= animationDelay)
        {
            isMouthOpen = !isMouthOpen;
            timer = 0f; // Reset timer for next animation cycle
        }

        // Update sprite visibility

        if(isPiranhaAlive)
        {
            mouthOpenSprite.enabled = isMouthOpen;
            mouthClosedSprite.enabled = !isMouthOpen;
        }

        if(!isPiranhaAlive)
        {
            Destroy(mouthOpenSprite);
            Destroy(mouthClosedSprite);
        }
       

        // Movement logic with limit checks
        if (transform.position.y >= upLimit)
        {
            isMovingUp = false;
        }
        else if (transform.position.y <= downLimit)
        {
            isMovingUp = true;
        }

        // Translate based on movement direction
        transform.Translate(Vector3.down * (isMovingUp ? -moveSpeed : moveSpeed) * Time.deltaTime);
    }
}

