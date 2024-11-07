// NOTE: Anything to do with Canvas Group in this script is useless. What I tried to do failed
// And I wasn't bothered to remove those code because I feared that I could accidently tamper with useful code in the process
// Since I don't want anything to break, I just left them there.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipTutorialWindow : MonoBehaviour
{
    public GameObject skipTutorialPanel;
    public Button noButton;
    public Button okayButton;

    private CanvasGroup canvasGroup;

    void Start()
    {
        noButton.onClick.AddListener(LoadTutorial);
        okayButton.onClick.AddListener(SkipTutorial);
        
        canvasGroup = skipTutorialPanel.GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (skipTutorialPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SkipTutorial();
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                LoadTutorial();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Close the exit confirmation window when Esc is pressed
                CloseConfirmation();
            }
        }
    }

    void CloseConfirmation()
    {
        // Hide the exit confirmation window when the cancel button or Esc key is clicked
        skipTutorialPanel.SetActive(false);
    }

    public void SkipTutorial()
    {
        SceneManager.LoadScene("Level_1");
        ClosePanel();
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialLevel");
        ClosePanel();
    }

    void ClosePanel()
    {
        skipTutorialPanel.SetActive(false);

        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
}