using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // This is crucial for scene switching

public class ClickToQuit : MonoBehaviour
{
    public Button quitButton; // Reference to the quit button
    public GameObject confirmationPanel; // Reference to the confirmation panel

    void Start()
    {
        Button btn = quitButton.GetComponent<Button>(); // Get the quit button component
        btn.onClick.AddListener(ShowConfirmation); // Add listener to show the confirmation panel
        confirmationPanel.SetActive(false); // Hide the confirmation panel when the game first starts
    }

    void Update()
    {
        // --- KEYBIND SHORTCUT ---
        // Esc to show confirmation panel
        
        // Check if the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Show the confirmation panel when Esc is pressed, but only if it's not already active
            if (!confirmationPanel.activeInHierarchy)
            {
                ShowConfirmation();
            }
        }
    }

    void ShowConfirmation()
    {
        // Show the confirmation panel when Quit is clicked
        confirmationPanel.SetActive(true);
    }
}