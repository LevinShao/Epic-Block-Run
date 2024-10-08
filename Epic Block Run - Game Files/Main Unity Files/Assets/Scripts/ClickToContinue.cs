using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // You MUST include this if you want to work with scenes / change scenes
using UnityEngine.UI; // You MUST include this to work with User Interfaces (buttons in this case)

public class ClickToContinue : MonoBehaviour
{
	public Button yourButton;
	public GameObject confirmationPanel; // Reference to the confirmation panel

	void Start () {
		Button btn = yourButton.GetComponent<Button>(); // Stores a button in the 'btn' variable
		btn.onClick.AddListener(TaskOnClick); // Checks to see if the Play button is clicked.
	}

    void Update()
	{
		// --- KEYBIND SHORTCUT ---
        // Enter/Return to begin Level 1

        // Only proceed to Level 1 if the confirmation panel is NOT active
        if (Input.GetKeyDown(KeyCode.Return) && !confirmationPanel.activeInHierarchy)
        {
            TaskOnClick();
        }
    }

	void TaskOnClick() {
		SceneManager.LoadScene("Level_1"); // Loads Level 1 if the button is clicked
	}
}