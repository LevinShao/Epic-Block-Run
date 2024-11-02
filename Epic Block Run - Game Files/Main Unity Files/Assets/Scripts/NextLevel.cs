using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Important, if working with scenes you MUST include this.
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private string targetScene;  // Allows the portals to decide whether they should teleport to Level 1 or the Challenge Level

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Check if the object colliding is the player
        {
            Destroy(gameObject); // Remove player from screen
            SceneManager.LoadScene(targetScene);  // Load the target scene
        }
    }
}