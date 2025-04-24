using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandInteraction : MonoBehaviour
{
    public XRController leftController;  // Kontroler lewej rêki
    public XRController rightController; // Kontroler prawej rêki
    private GameObject heldPiece = null;  // Pionek, który trzymamy

    void Update()
    {
        // Sprawdzamy, czy którykolwiek z kontrolerów jest aktywowany
        if (IsControllerActivated(leftController) || IsControllerActivated(rightController))
        {
            if (heldPiece == null)
            {
                // Detekcja, który pionek jest w zasiêgu
                RaycastHit hit;
                if (Physics.Raycast(leftController.transform.position, leftController.transform.forward, out hit) ||
                    Physics.Raycast(rightController.transform.position, rightController.transform.forward, out hit))
                {
                    if (hit.collider.CompareTag("WhiteChecker") || hit.collider.CompareTag("BlackChecker"))
                    {
                        heldPiece = hit.collider.gameObject;
                    }
                }
            }
        }

        // Jeœli trzymamy pionek, przesuwamy go za rêk¹
        if (heldPiece != null)
        {
            Vector3 controllerPosition = leftController.transform.position;
            if (IsControllerActivated(rightController))
                controllerPosition = rightController.transform.position;

            heldPiece.transform.position = controllerPosition;
        }
    }

    private bool IsControllerActivated(XRController controller)
    {
        // Sprawdzamy, czy przycisk 'triggerButton' jest wciœniêty na kontrolerze
        if (controller == null) return false;

        InputDevice device = controller.inputDevice;

        // Sprawdzamy, czy przycisk 'triggerButton' jest wciœniêty na kontrolerze
        return InputHelpers.IsPressed(device, InputHelpers.Button.Trigger, out bool isPressed) && isPressed;
    }

    void OnReleasePiece()
    {
        // Zwolnienie pionka
        heldPiece = null;
    }
}
