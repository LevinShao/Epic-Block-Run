using UnityEngine;

public class MusicResetter : MonoBehaviour
{
    public AudioSource BGM; // Reference to the BGM

    // Method to stop the background music when the player touches a spike
    public void StopMusic()
    {
        if (BGM != null)
        {
            BGM.Stop(); // Stop the music immediately
        }
    }

    // Method to reset the background music after respawn
    public void ResetMusic()
    {
        if (BGM != null)
        {
            BGM.Play(); // Play the music from the beginning
        }
    }
}