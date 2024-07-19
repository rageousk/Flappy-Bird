using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioClip dieSound; // Add a public variable for the die sound

    private bool isGameOver = false; // Flag to track game state

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }

    [ContextMenu("Increase Score")]

    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void gameOver()
    {
        if (!isGameOver) // Check if game over has already happened
        {
            isGameOver = true;
            gameOverScreen.SetActive(true);
            PlayDieSound(); // Call the function to play the die sound
            FindObjectOfType<FlapWings>().SetCanFlap(false); // Disable flap sound in FlapWings script
        }
    }

    private void PlayDieSound()
    {
        if (dieSound != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.PlayOneShot(dieSound);
            }
            else
            {
                Debug.LogError("No AudioSource component found on LogicScript object!");
            }
        }
        else
        {
            Debug.LogError("No dieSound clip assigned in LogicScript!");
        }
    }

}





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
} */