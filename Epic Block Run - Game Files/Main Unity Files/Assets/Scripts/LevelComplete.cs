// THIS SCRIPT CURRENTLY DOES NOT WORK, SORRY FOR THE INCONVENIENCE

using UnityEngine;

public class LevelComplete : MonoBehaviour
{
      public AudioSource JumpSound;

      void OnCollisionEnter(Collision collision)
      {
        JumpSound.Play();
      }
}
