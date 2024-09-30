using System.Collections;
using UnityEngine;

public class MusicResetter : MonoBehaviour
{
    public AudioSource backgroundMusic;  // Drag your BGM Audio Source here
    public GameObject player;            // Drag your player GameObject here

    void Update()
    {
        // Check if the player is inactive (disabled or destroyed)
        if (player == null || !player.activeInHierarchy)
        {
            ResetMusic();
        }
    }

    void ResetMusic()
    {
        // Stop and restart the background music
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
            backgroundMusic.Play();
        }
    }
}