using System.Collections;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public AttemptCounter attemptCounter; // Reference to the AttemptCounter.cs script
    public MusicResetter musicResetter; // Reference to the MusicResetter.cs script
    public AudioSource deathSound; // Reference to the DeathSound SFX
    public float respawnDelay = 0.5f; // Time before the player respawn
    public LevelTimer levelTimer; // Reference to the LevelTimer script

    private BoxCollider2D playerCollider;
    private Rigidbody2D rb;
    private Vector3 initialPosition; // Store the player's initial position

    void Start()
    {
        // Get the player's Box Collider and Rigidbody 2D component
        playerCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        // Store the player's initial position as the respawn point
        initialPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        // Check if the player collides with a deadly object (i.e. a spike)
        if (target.CompareTag("Deadly"))
        {
            HandleDeath();
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Deadly"))
        {
            HandleDeath();
        }
    }

    public void HandleDeath()
    {
        // Stop the background music immediately when the player dies
        if (musicResetter != null)
        {
            musicResetter.StopMusic();
        }

        // Play the DeathSound SFX
        if (deathSound != null)
        {
            deathSound.Play();
        }

        // Pause the timer immediately when the player dies
        if (levelTimer != null)
        {
            levelTimer.PauseTimer();
        }

        // Disable the player controls and collider
        playerCollider.enabled = false;
        rb.linearVelocity = Vector2.zero; // Stop the player movement

        // StartCoroutine is a method that you declare with an IEnumerator return type 
        // and with a yield return statement included somewhere in the body.

        // Wait for the death SFX to finish before respawning
        StartCoroutine(RespawnPlayer());
    }

    // IEnumerator is a fundamental interface for many of the collection types in C#
    // IEnumerator is crucial for the attempt counter and DeathSound SFX to work
    private IEnumerator RespawnPlayer()
    {
        // The yield return statement is crucial for the StartCoroutine and IEnumerator to work
        
        // Wait for 0.5 seconds so the death SFX could finish playing
        yield return new WaitForSeconds(respawnDelay);

        // Move the player to the initial position
        transform.position = initialPosition;

        // Reset the BGM, attempt counter and timer after player respawns
        if (attemptCounter != null)
        {
            attemptCounter.OnPlayerDeath();
        }

        if (levelTimer != null)
        {
            levelTimer.ResetTimer();
            levelTimer.ResumeTimer();
        }

        if (musicResetter != null)
        {
            musicResetter.ResetMusic();
        }

        // Re-enable the player's collider to allow interactions again
        playerCollider.enabled = true;
    }
}