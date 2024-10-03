using UnityEngine;
using UnityEngine.UI;

public class ConfirmationHandler : MonoBehaviour
{
    public Button confirmButton; // Reference to the Confirm button
    public Button cancelButton; // Reference to the Cancel button
    public GameObject confirmationPanel; // Reference to the Confirmation Panel

    void Start()
    {
        // Add listeners to the Confirm and Cancel buttons
        confirmButton.onClick.AddListener(QuitGame);
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

        // Basically does the same thing as above, except that this time the program will close itself when the "Enter/Return" key is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        // Quit the application when Confirm is clicked
        Application.Quit();
    }

    void CloseConfirmation()
    {
        // Hide the confirmation panel when Cancel or Esc is clicked
        confirmationPanel.SetActive(false);
    }
}