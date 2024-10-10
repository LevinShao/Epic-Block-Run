// This script is similar to SplashScreenQuitConfirmation.cs, but it's modified slightly so it can help the main levels' confirmation window achieve its functionality.

// THIS IS AN EXTENSION TO LevelExitButton.cs

// The "exit confirmation window" referenced in this script refers to the exit confirmation window for the main levels
// Not the exit confirmation window for the splash screen.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // This is crucial for scene switching

public class LevelExitButtonConfirmation : MonoBehaviour
{
    public Button confirmButton; // Reference to the confirm button
    public Button cancelButton; // Reference to the cancel button
    public GameObject exitConfirmationWindow; // Reference to the exit confirmation window

    void Start()
    {
        // Add listeners to the confirm and cancel buttons
        confirmButton.onClick.AddListener(QuitToSplashscreen);
        cancelButton.onClick.AddListener(CloseConfirmation);
    }

    void Update()
    {
    // Check if the Esc key is pressed
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        // Close the exit confirmation window when Esc is pressed
        CloseConfirmation();
    }

    if (Input.GetKeyDown(KeyCode.Return))
    {
        QuitToSplashscreen();
    }
    }

    void QuitToSplashscreen()
    {
        // Load the splash screen scene
        SceneManager.LoadScene("SplashScreen");
    }

    void CloseConfirmation()
    {
        // Hide the exit confirmation window
        exitConfirmationWindow.SetActive(false);
    }
}