using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabSoundAutoAdder : MonoBehaviour
{
    public AudioSource sharedGrabSound;

    private void Awake()
    {
        XRGrabInteractable[] interactables = FindObjectsOfType<XRGrabInteractable>();

        foreach (var interactable in interactables)
        {
            if (interactable.GetComponent<GrabSoundOnSelect>() == null)
            {
                var grabSound = interactable.gameObject.AddComponent<GrabSoundOnSelect>();
                grabSound.grabAudioSource = sharedGrabSound;
            }
        }
    }
}
