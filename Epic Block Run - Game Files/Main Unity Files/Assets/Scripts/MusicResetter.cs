// THIS SCRIPT CURRENTLY DOES NOT WORK, SORRY FOR THE INCONVENIENCE

using System.Collections;
using UnityEngine;

public class MusicResetter : MonoBehaviour
{
    public AudioSource backgroundMusic;  
    public GameObject player;            

    void Update()
    {
        // Check if the player is inactive
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