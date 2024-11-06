using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Important, if working with scenes you MUST include this.
using TMPro;

public class Collectible : MonoBehaviour
{
    private bool levelCompleted = false; // Ensure this only triggers once
    public GameObject collectible; // Reference to the checkpoint/end portal
    public GameObject player; // Reference to the player
    public AudioSource audioSource; // Reference to the level completion sound player's audio source component
    public TextMeshProUGUI completionText; // Reference to the level completion message
    public AudioClip levelCompleteSound; // Reference to the level completion SFX
    public Stopwatch stopwatch; // Reference to the Stopwatch script
    public GameObject pauseButton; // Reference to the pause button
    [SerializeField] private string targetScene;  // Let the player decide which scene the collectible should teleport the player to

    void Start()
    {
        completionText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player") && !levelCompleted)
        {
            levelCompleted = true; // Mark level as completed to avoid multiple triggers

            // Hide the collectible by disabling its SpriteRenderer
            SpriteRenderer sr = collectible.GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.enabled = false; // Hide the visual appearance of the collectible

            // Optionally disable its collider to prevent further interaction
            Collider2D collectibleCollider = collectible.GetComponent<Collider2D>();
            if (collectibleCollider != null)
                collectibleCollider.enabled = false;

            // Hide the player visually by disabling only the SpriteRenderer
            SpriteRenderer playerSr = player.GetComponent<SpriteRenderer>();
            if (playerSr != null)
                playerSr.enabled = false; // Hide the player's visual appearance

            // Deactivate the pause button when level is completed
            if (pauseButton != null)
            {
                pauseButton.SetActive(false);
            }

            // Play the level complete sound effect
            if (audioSource != null && levelCompleteSound != null)
            {
                audioSource.PlayOneShot(levelCompleteSound);
            }

            // Pause the stopwatch
            if (stopwatch != null)
            {
                stopwatch.PauseStopwatch();
            }

            // Freeze the game
            Time.timeScale = 0f;

            // Start the coroutine to handle the 3-second wait
            StartCoroutine(EndLevelSequence());
        }
    }

    // Coroutine to pause for 3 seconds before loading the next level
    private IEnumerator EndLevelSequence()
    {
        completionText.gameObject.SetActive(true);

        // Wait for 3 seconds while the game is frozen
        yield return new WaitForSecondsRealtime(3); // Use WaitForSecondsRealtime to ignore time scale

        // Load the next scene
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1f;

        // try-catch is similar to try-except in Python, but for C#
        try {
            SceneManager.LoadScene(targetScene);  // Load the target scene
        }
        catch {
            SceneManager.LoadScene("SplashScreen"); // Load Splash Screen if there are no more scenes
        }
    }
}