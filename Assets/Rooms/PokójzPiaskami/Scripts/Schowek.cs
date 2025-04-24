using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Schowek : MonoBehaviour
{
    public XRGrabInteractable lever;  // Przypisz tutaj düwigniÍ (XRGrabInteractable)
    public Animator compartmentAnimator;  // Przypisz tutaj Animator schowka

    private bool isActivated = false;  // Zmienna do sprawdzenia, czy düwignia zosta≥a juø aktywowana

    void Start()
    {
        lever.selectExited.AddListener(OnLeverPulled);  // Listener na zdarzenie, gdy düwignia zostanie puszczona
    }

    void OnLeverPulled(SelectExitEventArgs args)
    {
        if (!isActivated)
        {
            compartmentAnimator.SetTrigger("OpenSkrzynka");  // Ustawiamy Trigger otwierajπcy schowek
            isActivated = true;  // Zapobieganie ponownemu wyzwalaniu
            Debug.Log("Düwignia zosta≥a pociπgniÍta, otwieramy schowek.");
        }
    }
}