using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapWings : MonoBehaviour
{
    public Sprite downwing;
    public AudioClip flapSound; // Add a public variable for the audio clip

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource; // Add a reference to the AudioSource component
    private bool canFlap = true; // Flag to control flap sound based on game state

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canFlap)
        {
            transform.rotation = Quaternion.Euler(180f, 0f, 0f);
            StartCoroutine(RotateWings());
            PlayFlapSound(); // Call the function to play the audio
        }
    }

    IEnumerator RotateWings()
    {
        yield return new WaitForSeconds(0.1f);
        transform.rotation = Quaternion.identity;
    }

    private void PlayFlapSound() // Function to play the audio
    {
        if (flapSound != null && audioSource.isPlaying == false && canFlap)
        {
            audioSource.PlayOneShot(flapSound); // Play the flap sound
        }
    }

    // Function to be called by LogicScript when game over happens
    public void SetCanFlap(bool canFlap)
    {
        this.canFlap = canFlap;
    }
}







/*using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FlapWings : MonoBehaviour
{

    public Sprite downwing;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
              transform.rotation = Quaternion.Euler(180f, 0f, 0f);
              StartCoroutine(RotateWings());
        }
    }

    IEnumerator RotateWings()
    {
        yield return new WaitForSeconds(0.1f);
        transform.rotation = Quaternion.identity;
    }
} */
