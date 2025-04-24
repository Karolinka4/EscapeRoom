using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayInteractorController : MonoBehaviour
{
    [SerializeField] private XRRayInteractor rayInteractor; // Ray Interactor, kt�ry chcesz kontrolowa�

    private void Start()
    {
        // Na starcie mo�esz wy��czy� ray, je�li ma by� niedost�pny
        if (rayInteractor != null)
        {
            rayInteractor.enabled = false; // Wy��czony na pocz�tku gry
        }
    }

    public void EnableRay()
    {
        // W��czenie Ray Interactora
        if (rayInteractor != null)
        {
            rayInteractor.enabled = true;
        }
    }

    public void DisableRay()
    {
        // Wy��czenie Ray Interactora
        if (rayInteractor != null)
        {
            rayInteractor.enabled = false;
        }
    }
}
