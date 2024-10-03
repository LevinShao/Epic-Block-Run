using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // This helps to switch scenes

public class ClickToQuit : MonoBehaviour
{
    public Button quitButton; // Reference to the Quit button
    public GameObject confirmationPanel; // Reference to the Confirmation Panel

    void Start()
    {
        Button btn = quitButton.GetComponent<Button>(); // Get the Quit button component
        btn.onClick.AddListener(ShowConfirmation); // Add listener to show the confirmation panel
        confirmationPanel.SetActive(false); // Hide the confirmation panel initially
    }

	void Update()
    {
        // Check if the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Show the confirmation panel when Esc is pressed
            ShowConfirmation();
        }

        // Basically does the same thing as above, except that this time Level 1 will begin when the "Enter/Return" key is pressed
		if (Input.GetKeyDown(KeyCode.Return))
        {
            Proceed();
        }
    }

	void Proceed()
    {
        // Load Level 1 when the Return/Enter key is clicked
        SceneManager.LoadScene("Level_1");
    }

    void ShowConfirmation()
    {
        // Show the confirmation panel when Quit is clicked
        confirmationPanel.SetActive(true);
    }
}