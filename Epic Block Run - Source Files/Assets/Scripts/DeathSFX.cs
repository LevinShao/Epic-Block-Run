using UnityEngine;

public class DeathSFX : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding is the player
        if (other.CompareTag("Player"))
        {
            // Play the sound effect
            audioSource.Play();
        }
    }
}
