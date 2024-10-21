using UnityEngine;
using UnityEngine.UI;

public class BGMVolumeAdjuster : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the slider
    public AudioSource BGMAudioSource; // Reference to the BGM

    void Start()
    {
        // Set the slider's value to the current volume level
        volumeSlider.value = BGMAudioSource.volume;

        // Add a listener to call OnVolumeChange when the slider's value changes
        volumeSlider.onValueChanged.AddListener(OnVolumeChange);
    }

    // Change the volume
    void OnVolumeChange(float volume)
    {
        BGMAudioSource.volume = volume;
    }
}