using UnityEngine;
using UnityEngine.UI;

public class QuitConfirmationWindow : MonoBehaviour
{
    public Button confirmButton; // Reference to the confirm button
    public Button cancelButton; // Reference to the cancel button
    public GameObject exitConfirmationWindow; // Reference to the exit confirmation window

    void Start()
    {
        // Add listeners to the confirm and cancel buttons
        confirmButton.onClick.AddListener(QuitGame);
        cancelButton.onClick.AddListener(CloseConfirmation);
    }

    void Update()
    {
        // --- KEYBIND SHORTCUTS ---

        // ESC to close the exit confirmation window
        // Check if the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Close the exit confirmation window when Esc is pressed
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
        // Hide the exit confirmation window when the cancel button or Esc key is clicked
        exitConfirmationWindow.SetActive(false);
    }
}