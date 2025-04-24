using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Dźwignia : MonoBehaviour
{
    public Transform lever; // Przypisz dźwignię
    public float rotationAmount = 45f; // Kąt rotacji dźwigni w stopniach
    public float rotationSpeed = 5f; // Szybkość rotacji
    private Vector3 initialRotation;
    private bool isBeingHeld = false;

    void Start()
    {
        initialRotation = lever.localEulerAngles; // Zapamiętaj początkową rotację dźwigni
    }

    void Update()
    {
        // Sprawdź, czy dźwignia jest chwycona
        if (lever.GetComponent<XRGrabInteractable>().isSelected)
        {
            isBeingHeld = true;

            // Oblicz nowy kąt rotacji wokół osi Z
            float newZ = Mathf.LerpAngle(lever.localEulerAngles.z, initialRotation.z - rotationAmount, Time.deltaTime * rotationSpeed);
            lever.localEulerAngles = new Vector3(lever.localEulerAngles.x, lever.localEulerAngles.y, newZ);
        }
        else if (isBeingHeld)
        {
            // Po odłączeniu, przywróć dźwignię do początkowej rotacji
            lever.localEulerAngles = initialRotation;
            isBeingHeld = false;
        }
    }
}