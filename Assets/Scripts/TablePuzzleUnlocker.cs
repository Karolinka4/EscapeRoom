using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TablePuzzleUnlocker : MonoBehaviour
{
    public GameObject[] requiredObjects; // Dok�adne obiekty, kt�re musz� by� na stole

    public GameObject objectToUnlock; // Obiekt, kt�ry ma zosta� odblokowany

    private HashSet<GameObject> presentObjects = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (IsRequiredObject(obj))
        {
            presentObjects.Add(obj);
            CheckPuzzleComplete();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (presentObjects.Contains(obj))
        {
            presentObjects.Remove(obj);
        }
    }


    private bool IsRequiredObject(GameObject obj)
    {
        foreach (var required in requiredObjects)
        {
            if (obj == required) // por�wnanie referencji, nie nazw
                return true;
        }
        return false;
    }

    private void CheckPuzzleComplete()
    {
        if (presentObjects.Count == requiredObjects.Length)
        {
            Debug.Log("Wszystkie przedmioty na miejscu! Odblokowuj� obiekt.");

            objectToUnlock.SetActive(true);

            XRGrabInteractable grab = objectToUnlock.GetComponent<XRGrabInteractable>();
            if (grab != null)
                grab.enabled = true;
        }
    }
}
