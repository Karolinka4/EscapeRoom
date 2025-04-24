using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SlotCheckerXR : MonoBehaviour
{
    private SlotChecker slotChecker;
    private CheckerManager checkerManager;

    private void Start()
    {
        slotChecker = GetComponent<SlotChecker>();
        checkerManager = FindObjectOfType<CheckerManager>(); // Znajduje CheckerManager w scenie
        GetComponent<XRSocketInteractor>().selectEntered.AddListener(OnCubePlaced);
        GetComponent<XRSocketInteractor>().selectExited.AddListener(OnCubeRemoved);
    }

    private void OnCubePlaced(SelectEnterEventArgs args)
    {
        CubeNumber cube = args.interactableObject.transform.GetComponent<CubeNumber>();
        if (cube != null)
        {
            slotChecker.SetPlacedCube(cube);
            checkerManager?.CheckWin(); // Sprawdzamy wygran¹
        }
    }

    private void OnCubeRemoved(SelectExitEventArgs args)
    {
        slotChecker.ClearSlot();
        checkerManager?.CheckWin(); // Sprawdzamy ponownie po zabraniu cube’a
    }
}
