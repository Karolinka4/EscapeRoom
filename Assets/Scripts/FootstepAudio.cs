using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FootstepAudio : MonoBehaviour
{
    public AudioSource footstepSource;
    public AudioClip footstepClip;
    public float stepInterval = 0.5f;

    private CharacterController characterController;
    private float stepTimer;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController == null)
            return;

        // Sprawdza czy gracz siê porusza
        if (characterController.velocity.magnitude > 0.1f)
        {
            stepTimer += Time.deltaTime;

            if (stepTimer >= stepInterval)
            {
                footstepSource.PlayOneShot(footstepClip);
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = stepInterval; // resetujemy licznik jeœli nie idzie
        }
    }
}
