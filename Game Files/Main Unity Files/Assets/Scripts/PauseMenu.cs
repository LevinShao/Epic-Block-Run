// SOME PARTS OF THIS SCRIPT ARE BROKEN, I'LL TRY MY BEST TO FIX THEM

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;  // Reference to the Pause Menu
    public Button quitButton;       // Quit button
    public Button resumeButton;     // Resume button
    public Button restartButton;    // Restart button
    public Explode playerExplodeScript; // Reference to the Explode.cs script

    private bool isPaused = false;

    void Start()
    {
        // Assign button listeners
        quitButton.onClick.AddListener(QuitToSplashscreen);
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartLevel);
    }

    void Update()
    {
        // Listen for pause/unpause inputs
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // If already paused, resume the game
            }
            else
            {
                PauseGame();  // If not paused, pause the game
            }
        }
    }

    // Method to pause the game
    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);  // Show the pause menu
        Time.timeScale = 0f;          // Freeze all game time
    }

    // Method to resume the game
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f;          // Unfreeze game time
    }

    // Method to restart the level
    public void RestartLevel()
    {
        ResumeGame(); // Unpause the game before restarting
        if (playerExplodeScript != null)
        {
            playerExplodeScript.HandleDeath(); // Trigger player death and respawn
        }
    }

    // Method to quit to the splash screen
    public void QuitToSplashscreen()
    {
        Time.timeScale = 1f; // Ensure time is running again
        SceneManager.LoadScene("SplashScreen"); // Load the splash screen
    }
}