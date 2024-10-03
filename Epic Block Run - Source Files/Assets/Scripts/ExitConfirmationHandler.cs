using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Add this to switch scenes

public class ExitConfirmationHandler : MonoBehaviour
{
    public Button confirmButton; // Reference to the Confirm button
    public Button cancelButton; // Reference to the Cancel button
    public GameObject exitConfirmationPanel; // Reference to the Exit Confirmation Panel

    void Start()
    {
        // Add listeners to the Confirm and Cancel buttons
        confirmButton.onClick.AddListener(QuitToSplashscreen);
        cancelButton.onClick.AddListener(CloseConfirmation);
    }

    void Update()
    {
    // Check if the Esc key is pressed
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        // Close the confirmation panel when Esc is pressed
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
        // Hide the exit confirmation panel
        exitConfirmationPanel.SetActive(false);
    }
}