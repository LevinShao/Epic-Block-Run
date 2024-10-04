using UnityEngine;
using UnityEngine.UI;

public class ExitButtonHandler : MonoBehaviour
{
    public Button exitButton; // Reference to the exit button
    public GameObject exitConfirmationPanel; // Reference to the exit confirmation panel

    void Start()
    {
        // Add a listener to the exit button
        exitButton.onClick.AddListener(ToggleExitConfirmation);
    }

    void Update()
    {
    // Check if the Esc key is pressed
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        // Close the confirmation panel when Esc is pressed
        ToggleExitConfirmation();
    }
    }

    void ToggleExitConfirmation()
    {
        // Toggle the active state of the exit confirmation panel
        exitConfirmationPanel.SetActive(!exitConfirmationPanel.activeSelf);
    }
}