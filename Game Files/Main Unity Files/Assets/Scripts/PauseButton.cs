using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Button pauseButton; // Reference to the pause button
    public GameObject pauseMenu; // Reference to the pause menu

    void Start()
    {
        // Add a listener to the pause button
        pauseButton.onClick.AddListener(ToggleExitConfirmation);
    }

    void Update()
    {
        // Check if the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Close the pause menu when Esc is pressed
            ToggleExitConfirmation();
        }
    }

    void ToggleExitConfirmation()
    {
        // Toggle the active state of the pause menu
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
}