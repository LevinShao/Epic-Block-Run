using UnityEngine;
using TMPro;

public class AttemptCounter : MonoBehaviour
{
    public TextMeshProUGUI attemptText; // Reference to the attempt counter text
    private int attemptCount = 1; // Start from attempt 1

    void Start()
    {
        // Initialize the attempt text
        UpdateAttemptText();
    }

    // This method is called when the player dies
    public void OnPlayerDeath()
    {
        attemptCount++; // Increase the number on the attempt counter by 1
        UpdateAttemptText(); // Update the UI text visually before player respawns
    }

    // Method to update the UI text visually before player respawns
    private void UpdateAttemptText()
    {
        attemptText.text = "Attempt " + attemptCount;
    }
}