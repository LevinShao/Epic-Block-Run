using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Button playButton;
    public GameObject skipTutorialWindow;
    public GameObject quitConfirmationWindow; // Reference to quit confirmation window

    private CanvasGroup canvasGroup; // Canvas Group to control interaction for skip tutorial

    void Start()
    {
        Button btn = playButton.GetComponent<Button>();
        btn.onClick.AddListener(ShowSkipTutorialWindow);

        canvasGroup = skipTutorialWindow.GetComponent<CanvasGroup>();
    }

    void Update()
    {
        // Keybind to show the skip tutorial window if quit confirmation window is not active
        if (Input.GetKeyDown(KeyCode.Return) && !quitConfirmationWindow.activeInHierarchy)
        {
            ShowSkipTutorialWindow();
        }

        // Ensure Esc closes skip tutorial window if active, or opens quit confirmation if not
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (skipTutorialWindow.activeInHierarchy)
            {
                CloseSkipTutorialWindow();
            }
            else if (!quitConfirmationWindow.activeInHierarchy)
            {
                // The quit confirmation window will handle its Esc functionality, so this doesn't have to have anything
            }
        }
    }

    void ShowSkipTutorialWindow()
    {
        skipTutorialWindow.SetActive(true);
        
        // Disable interaction with the rest of the UI while skip tutorial window is active
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public void CloseSkipTutorialWindow()
    {
        skipTutorialWindow.SetActive(false);

        // Re-enable interaction with other UI elements
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
}