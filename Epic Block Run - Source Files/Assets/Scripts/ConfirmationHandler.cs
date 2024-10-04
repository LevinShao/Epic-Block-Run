// THIS IS AN EXTENSION TO ClickToQuit.cs

using UnityEngine;
using UnityEngine.UI;

public class ConfirmationHandler : MonoBehaviour
{
    public Button confirmButton; // Reference to the confirm button
    public Button cancelButton; // Reference to the cancel button
    public GameObject confirmationPanel; // Reference to the confirmation panel

    void Start()
    {
        // Add listeners to the confirm and cancel buttons
        confirmButton.onClick.AddListener(QuitGame);
        cancelButton.onClick.AddListener(CloseConfirmation);
    }

    void Update()
    {
        // --- KEYBIND SHORTCUTS ---

        // ESC to close confirmation panel
        // Check if the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Close the confirmation panel when Esc is pressed
            CloseConfirmation();
        }

        // Enter/Return to quit and close the game
        if (Input.GetKeyDown(KeyCode.Return))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        // Quit the application when the confirm button or Enter/Return key is clicked
        Application.Quit();
    }

    void CloseConfirmation()
    {
        // Hide the confirmation panel when the cancel button or Esc key is clicked
        confirmationPanel.SetActive(false);
    }
}