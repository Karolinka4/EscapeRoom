using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Schowek : MonoBehaviour
{
    public XRGrabInteractable lever;  // Przypisz tutaj d�wigni� (XRGrabInteractable)
    public Animator compartmentAnimator;  // Przypisz tutaj Animator schowka

    private bool isActivated = false;  // Zmienna do sprawdzenia, czy d�wignia zosta�a ju� aktywowana

    void Start()
    {
        lever.selectExited.AddListener(OnLeverPulled);  // Listener na zdarzenie, gdy d�wignia zostanie puszczona
    }

    void OnLeverPulled(SelectExitEventArgs args)
    {
        if (!isActivated)
        {
            compartmentAnimator.SetTrigger("OpenSkrzynka");  // Ustawiamy Trigger otwieraj�cy schowek
            isActivated = true;  // Zapobieganie ponownemu wyzwalaniu
            Debug.Log("D�wignia zosta�a poci�gni�ta, otwieramy schowek.");
        }
    }
}