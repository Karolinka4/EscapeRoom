using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabSoundOnSelect : MonoBehaviour
{
    public AudioSource grabAudioSource;

    private void OnEnable()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        if (interactable != null)
            interactable.selectEntered.AddListener(PlayGrabSound);
    }

    private void OnDisable()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        if (interactable != null)
            interactable.selectEntered.RemoveListener(PlayGrabSound);
    }

    private void PlayGrabSound(SelectEnterEventArgs args)
    {
        if (grabAudioSource != null && !grabAudioSource.isPlaying)
            grabAudioSource.Play();
    }
}
