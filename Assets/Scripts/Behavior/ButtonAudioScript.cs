using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioScript : MonoBehaviour
{
    public AudioClip buttonClickSound;  // Assign the audio clip for the button click in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Get or add an AudioSource component to this GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Method to be called when the button is clicked
    public void PlayButtonSound()
    {
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);  // Play the button click sound
        }
        else
        {
            Debug.LogWarning("No AudioClip assigned for button click!");
        }
    }
}
