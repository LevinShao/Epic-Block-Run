using System.Collections;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public AttemptCounter attemptCounter; // Reference to the AttemptCounter.cs script
    public MusicResetter musicResetter; // Reference to the MusicResetter.cs script
    public float respawnDelay = 0.1f; // Time before the player respawns

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
        // Check if the player collides with a deadly object
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
        // Disable player controls and collider
        playerCollider.enabled = false;
        rb.velocity = Vector2.zero; // Stop the player movement

        // Increment the attempt counter
        attemptCounter.OnPlayerDeath();

        // Reset the background music
        if (musicResetter != null)
        {
            musicResetter.ResetMusic();
        }

        // Start the respawn process
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        // Wait for a brief delay before respawning
        yield return new WaitForSeconds(respawnDelay);

        // Move the player to the initial position where the player started the level
        transform.position = initialPosition;

        // Enable the player's collider again
        playerCollider.enabled = true;
    }
}