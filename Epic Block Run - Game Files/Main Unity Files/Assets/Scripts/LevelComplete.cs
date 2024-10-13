// THIS SCRIPT CURRENTLY DOES NOT WORK, SORRY FOR THE INCONVENIENCE

using UnityEngine;

public class LevelComplete : MonoBehaviour
{
      public AudioSource LevelCompleteSound;

      void OnCollisionEnter(Collision collision)
      {
        LevelCompleteSound.Play();
      }
}