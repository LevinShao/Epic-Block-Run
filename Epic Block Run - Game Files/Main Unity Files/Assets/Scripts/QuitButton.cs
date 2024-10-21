using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // This is crucial for scene switching

public class QuitButton : MonoBehaviour
{
    public Button quitButton; // Reference to the quit button
    public GameObject exitConfirmationWindow; // Reference to the exit confirmation window

    void Start()
    {
        Button btn = quitButton.GetComponent<Button>(); // Get the quit button component
        btn.onClick.AddListener(ShowConfirmation); // Add listener to show the exit confirmation window when quit button is pressed
        exitConfirmationWindow.SetActive(false); // Hide the exit confirmation window when the game first starts
    }

    void Update()
    {
        // --- KEYBIND SHORTCUT ---
        // Esc to show the exit confirmation window
        
        // Check if the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Show the exit confirmation window when Esc is pressed, but only if it's not already active
            if (!exitConfirmationWindow.activeInHierarchy)
            {
                ShowConfirmation();
            }
        }
    }

    void ShowConfirmation()
    {
        // Show the exit confirmation window when Quit is clicked
        exitConfirmationWindow.SetActive(true);
    }
}