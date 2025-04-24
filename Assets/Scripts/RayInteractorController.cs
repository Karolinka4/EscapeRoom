using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayInteractorController : MonoBehaviour
{
    [SerializeField] private XRRayInteractor rayInteractor; // Ray Interactor, który chcesz kontrolowaæ

    private void Start()
    {
        // Na starcie mo¿esz wy³¹czyæ ray, jeœli ma byæ niedostêpny
        if (rayInteractor != null)
        {
            rayInteractor.enabled = false; // Wy³¹czony na pocz¹tku gry
        }
    }

    public void EnableRay()
    {
        // W³¹czenie Ray Interactora
        if (rayInteractor != null)
        {
            rayInteractor.enabled = true;
        }
    }

    public void DisableRay()
    {
        // Wy³¹czenie Ray Interactora
        if (rayInteractor != null)
        {
            rayInteractor.enabled = false;
        }
    }
}
