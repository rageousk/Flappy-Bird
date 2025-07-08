using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapJump;
    public GameObject shootArrow;
    public LogicScript logic;
    public AudioClip shootSound; // Add a public variable for the audio clip
    private AudioSource audioSource; // Add a reference to the AudioSource component
    public bool birdIsAlive = true;

    // Start is called before the first frame update and just runs precisely once
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame and runs constantly while the script is enabled
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapJump;
        }

        // Arrow Shooting
        if (Input.GetKeyDown(KeyCode.F) && birdIsAlive) // Added check for birdIsAlive
        {
            ShootArrow();
            PlayShootSound(); // Call the new PlayShootSound function
        }
    }

    void ShootArrow()
    {
        GameObject arrowInstance = Instantiate(shootArrow, transform.position + (Vector3.right * 0.3f), Quaternion.identity);
        arrowInstance.GetComponent<Rigidbody2D>().velocity = Vector2.right * 7.5f; // Adjust arrow speed
    }

    // New function to play the audio source
    private void PlayShootSound()
    {

        if (shootSound != null && audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(shootSound); // Play the flap sound
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}




/* ----- The below code can be useful, and I just kept it commented ------ */


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapJump;
    public GameObject shootArrow;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update and it just runs precisely once
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame and runs constantly while the script is enabled
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapJump;
        }

        // Arrow Shooting
        if (Input.GetKeyDown(KeyCode.F) && birdIsAlive) // Added check for birdIsAlive
        {
            ShootArrow();
        }
    }

    void ShootArrow()
    {
        GameObject arrowInstance = Instantiate(shootArrow, transform.position + (Vector3.right * 0.3f), Quaternion.identity);
        arrowInstance.GetComponent<Rigidbody2D>().velocity = Vector2.right * 7.5f; // Adjust arrow speed
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
} */





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapJump;
    public GameObject shootArrow;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update and it just runs precisely once
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame and runs constantly while the script is enabled
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapJump;
        }

        //Arrow Shooting

        if (Input.GetKeyDown(KeyCode.F))
        {
            ShootArrow();
        }
    }

    void ShootArrow()
    {
        GameObject arrowInstance = Instantiate(shootArrow, transform.position + (Vector3.right * 0.3f), Quaternion.identity);
        arrowInstance.GetComponent<Rigidbody2D>().velocity = Vector2.right * 7.5f; // Adjust arrow speed
    }


   private void OnCollisionEnter2D(Collision2D collision)
      {
          logic.gameOver();
          birdIsAlive = false;
      } 

} */
