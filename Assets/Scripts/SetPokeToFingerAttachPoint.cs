using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetPokeToFingerAttachPoint : MonoBehaviour
{
    public Transform PokeAttachPoint;  // Punkt zaczepienia dla Poke Interactor

    private XRPokeInteractor _xrPokeInteractor;  // Referencja do XRPokeInteractor

    void Start()
    {
        // Znajdowanie XRPokeInteractor w hierarchii obiektu
        _xrPokeInteractor = transform.parent.GetComponentInChildren<XRPokeInteractor>();
        SetPokeAttachPoint();
    }

    void SetPokeAttachPoint()
    {
        // Sprawdzanie, czy punkt zaczepienia zosta³ przypisany
        if (PokeAttachPoint == null)
        {
            Debug.LogError("Poke Attach Point is null");
            return;
        }

        // Sprawdzanie, czy XRPokeInteractor zosta³ poprawnie znaleziony
        if (_xrPokeInteractor == null)
        {
            Debug.LogError("XR Poke Interactor is null");
            return;
        }

        // Przypisywanie punktu zaczepienia do Poke Interactor
        _xrPokeInteractor.attachTransform = PokeAttachPoint;
        Debug.Log("Punkt zaczepienia zosta³ przypisany do XR Poke Interactor.");
    }
}
