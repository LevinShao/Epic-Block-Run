using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Must inport this for volume percentage text to update

public class BGMVolumeAdjuster : MonoBehaviour
{
    public Slider volumeSlider;  // Reference to the volume slider
    public AudioSource BGM;      // Reference to the BGM
    public TextMeshProUGUI volumePercentageText;  // Reference to the volume percentage text

    // PlayerPrefs is a class that stores Player preferences between game sessions
    // In this scenario, I am using PlayerPrefs to store the Player's preferred BGM volume setting

    // Even if the player exits a level or leaves the game completely, PlayerPrefs will still remember and store their volume setting
    // Meaning that the player will not need to reset the BGM volume every time they replay the game
    // Since PlayerPrefs will automatically set the BGM volume to the same as from their last session as soon they rejoin the game
    
    // The player also will not need to reset the BGM volume when they reach a new level
    // Since the following script will retain the player's preferred BGM volume across multiple levels

    private void Start()
    {
        // Load saved volume when the game starts using PlayerPrefs
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            volumeSlider.value = savedVolume; // Set slider value based on saved volume
            BGM.volume = savedVolume; // Set BGM volume based on saved volume
        }
        else
        {
            // Set default volume to 0.8 if no saved volume
            volumeSlider.value = 0.8f; // Set slider to 0.8
            BGM.volume = 0.8f; // Set volume to 0.8
        }

        // Update the volume percentage text when the game starts
        UpdateVolumeText(volumeSlider.value);

        // Add listener to slider to handle changes dynamically
        volumeSlider.onValueChanged.AddListener(delegate { AdjustVolume(); });
    }

    public void AdjustVolume()
    {
        // Adjust the music volume based on the slider value
        BGM.volume = volumeSlider.value;

        // Save the volume setting using PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
        PlayerPrefs.Save();

        // Update the volume percentage text
        UpdateVolumeText(volumeSlider.value);
    }

    private void UpdateVolumeText(float volume)
    {
        // Convert the slider value, which was originally in a decimal, to a percentage by multiplying it by 100
        int volumePercentage = Mathf.RoundToInt(volume * 100);

        // Set the volume percentage text to display the percentage
        volumePercentageText.text = volumePercentage.ToString() + "%";
    }
}