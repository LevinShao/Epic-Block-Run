// This script is similar to SplashScreenQuit.cs, but it's slightly modified so it can help the main levels' exit button achieve its functionality.

// LevelExitButtonConfirmation.cs CANNOT FUNCTION WITHOUT THIS SCRIPT
// SO EITHER DON'T DELETE THIS SCRIPT OR DELETE BOTH SCRIPTS, BUT IF YOU DELETE IT THEN THE EXIT BUTTON WON'T WORK
// SO UNLESS IF YOU WANT TO REMOVE THE EXIT BUTTON COMPLETELY, I'D RECOMMEND TO JUST LEAVE THIS SCRIPT ALONE

// The "exit confirmation window" referenced in this script refers to the exit confirmation window for the main levels
// Not the exit confirmation window for the splash screen.

using UnityEngine;
using UnityEngine.UI;

public class LevelExitButton : MonoBehaviour
{
    public Button exitButton; // Reference to the exit button
    public GameObject exitConfirmationWindow; // Reference to the exit confirmation window

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
        // Close the exit confirmation window when Esc is pressed
        ToggleExitConfirmation();
    }
    }

    void ToggleExitConfirmation()
    {
        // Toggle the active state of the exit confirmation window
        exitConfirmationWindow.SetActive(!exitConfirmationWindow.activeSelf);
    }
}