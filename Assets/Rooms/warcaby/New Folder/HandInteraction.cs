using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandInteraction : MonoBehaviour
{
    public XRController leftController;  // Kontroler lewej r�ki
    public XRController rightController; // Kontroler prawej r�ki
    private GameObject heldPiece = null;  // Pionek, kt�ry trzymamy

    void Update()
    {
        // Sprawdzamy, czy kt�rykolwiek z kontroler�w jest aktywowany
        if (IsControllerActivated(leftController) || IsControllerActivated(rightController))
        {
            if (heldPiece == null)
            {
                // Detekcja, kt�ry pionek jest w zasi�gu
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

        // Je�li trzymamy pionek, przesuwamy go za r�k�
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
        // Sprawdzamy, czy przycisk 'triggerButton' jest wci�ni�ty na kontrolerze
        if (controller == null) return false;

        InputDevice device = controller.inputDevice;

        // Sprawdzamy, czy przycisk 'triggerButton' jest wci�ni�ty na kontrolerze
        return InputHelpers.IsPressed(device, InputHelpers.Button.Trigger, out bool isPressed) && isPressed;
    }

    void OnReleasePiece()
    {
        // Zwolnienie pionka
        heldPiece = null;
    }
}
