using UnityEngine;
using TMPro;

public class AttemptCounter : MonoBehaviour
{
    public TextMeshProUGUI attemptText; // Reference to the TextMeshProUGUI element
    private int attemptCount = 1; // Start from attempt 1

    void Start()
    {
        // Initialize the attempt text
        UpdateAttemptText();
    }

    // This method is called when the player dies
    public void OnPlayerDeath()
    {
        attemptCount++; // Increment the attempt counter
        UpdateAttemptText(); // Update the UI text
    }

    // Updates the attempt text on the UI
    private void UpdateAttemptText()
    {
        attemptText.text = "Attempt " + attemptCount;
    }
}