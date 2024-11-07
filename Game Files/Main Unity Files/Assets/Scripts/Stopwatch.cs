using UnityEngine;
using TMPro;  // must import this for stopwatch to work

public class Stopwatch : MonoBehaviour
{
    public TextMeshProUGUI stopwatchText; // Reference to the stopwatch text
    private float stopwatch = 0f;
    private bool isTiming = true;

    void Update()
    {
        // Increment the stopwatch if timing is enabled
        if (isTiming)
        {
            stopwatch += Time.deltaTime;
            // This formats the stopwatch to 2 decimal places
            stopwatchText.text = stopwatch.ToString("F2");
        }
    }

    public void ResetStopwatch()
    {
        // Reset the stopwatch back to 0 seconds
        stopwatch = 0f;
    }

    public void PauseStopwatch()
    {
        // Pause the stopwatch
        isTiming = false;
    }

    public void ResumeStopwatch()
    {
        // Resume the stopwatch after it had been paused
        isTiming = true;
    }
}