using UnityEngine;

public class MusicResetter : MonoBehaviour
{
    public AudioSource BGMSource; // Reference to the AudioSource component on the BGM GameObject

    // Method to reset the background music
    public void ResetMusic()
    {
        if (BGMSource != null)
        {
            BGMSource.Stop(); // Stop the music
            BGMSource.Play(); // Play the music from the beginning
        }
    }
}