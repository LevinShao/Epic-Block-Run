using UnityEngine;

public class MusicResetter : MonoBehaviour
{
    public AudioSource BGMSource; // Reference to the BGM GameObject's AudioSource component

    // Method to stop the background music when the player touches a spike
    public void StopMusic()
    {
        if (BGMSource != null)
        {
            BGMSource.Stop(); // Stop the music immediately
        }
    }

    // Method to reset the background music after respawn
    public void ResetMusic()
    {
        if (BGMSource != null)
        {
            BGMSource.Play(); // Play the music from the beginning
        }
    }
}