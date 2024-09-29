using System.Collections;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private CapsuleCollider2D playerCollider;
    public Vector3 respawnPosition;
    public float respawnDelay = 0.3f; // Time to wait before respawning

    void Start()
    {
        // Get the CapsuleCollider2D component attached to the Player GameObject
        playerCollider = GetComponent<CapsuleCollider2D>();
        respawnPosition = transform.position; // Set initial respawn position
    }

    // This is called when another Collider2D enters the trigger zone of this GameObject.
    void OnTriggerEnter2D(Collider2D target)
    {
        // Check if the entering GameObject has the Deadly tag
        if (target.gameObject.CompareTag("Deadly"))
        {
            StartCoroutine(Respawn());
        }
    }

    // This is called when a collision with another Collider2D occurs.
    void OnCollisionEnter2D(Collision2D target)
    {
        // Check if the colliding GameObject has the Deadly tag
        if (target.gameObject.CompareTag("Deadly"))
        {
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        // Disable the CapsuleCollider2D on the Player to prevent further collisions
        if (playerCollider != null)
        {
            playerCollider.enabled = false;
        }

        yield return new WaitForSeconds(respawnDelay); // Wait for a short period before respawning

        // Reset the player's position
        transform.position = respawnPosition; // Move player back to respawn position

        // Re-enable the CapsuleCollider2D
        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }
    }
}