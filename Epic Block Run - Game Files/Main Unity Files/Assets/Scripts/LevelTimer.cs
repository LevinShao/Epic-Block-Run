using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the Level Timer TMP Text
    private float timer = 0f;
    private bool isTiming = true;

    void Update()
    {
        // Increment the timer if timing is enabled
        if (isTiming)
        {
            timer += Time.deltaTime;
            // This formats the timer UI to 2 decimal places
            timerText.text = timer.ToString("F2");
        }
    }

    public void ResetTimer()
    {
        // Reset the timer back to 0 seconds
        timer = 0f;
    }

    public void PauseTimer()
    {
        // Pause the timer
        isTiming = false;
    }

    public void ResumeTimer()
    {
        // Resume the timer after it had been paused
        isTiming = true;
    }
}