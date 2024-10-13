using System.Collections;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public AttemptCounter attemptCounter; // Reference to the AttemptCounter.cs script
    public MusicResetter musicResetter; // Reference to the MusicResetter.cs script
    public AudioSource deathSound; // Reference to the DeathSound SFX
    public float respawnDelay = 0.5f; // Time before the player respawns

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

    private void HandleDeath()
    {
        // Stop the background music immediately when the player dies
        if (musicResetter != null)
        {
            musicResetter.StopMusic(); // A method for resetting the music
        }

        // Play the DeathSound SFX
        if (deathSound != null)
        {
            deathSound.Play();
        }

        // Disable the player controls and collider
        playerCollider.enabled = false;
        rb.velocity = Vector2.zero; // Stop the player movement

        // StartCoroutine is a method that you declare with an IEnumerator return type 
        // and with a yield return statement included somewhere in the body.

        // Start the respawn process
        StartCoroutine(RespawnPlayer());
    }

    // IEnumerator is a fundamental interface for many of the collection types in C#
    // IEnumerator is crucial for the attempt counter and DeathSound SFX to work
    private IEnumerator RespawnPlayer()
    {
        // The yield return statement is crucial for the StartCoroutine and IEnumerator to work
        
        // Wait for the respawn delay while the DeathSound SFX is playing
        yield return new WaitForSeconds(respawnDelay);

        // Move the player to the initial position where the player started the level
        transform.position = initialPosition;

        // Update the attempt counter and reset the music after respawning
        if (attemptCounter != null)
        {
            attemptCounter.OnPlayerDeath();
        }

        if (musicResetter != null)
        {
            musicResetter.ResetMusic();
        }

        // Enable the player's collider again when the player respawns
        playerCollider.enabled = true;
    }
}