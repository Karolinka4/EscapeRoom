using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Ta metoda b�dzie wywo�ana przez Event w animacji
    public void PlayMySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
