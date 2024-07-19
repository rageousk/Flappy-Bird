using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPiranhaAnimation : MonoBehaviour
{
    public SpriteRenderer mouthOpenSprite;
    public SpriteRenderer mouthClosedSprite;
    public bool isMouthOpen = true;

    // Animation variables
    public float animationDelay = 0.2f; // Delay between open and closed mouth (seconds)
    private float timer = 0f;

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
        mouthOpenSprite.enabled = isMouthOpen;
        mouthClosedSprite.enabled = !isMouthOpen;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }


}
