using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SlotSamochod : MonoBehaviour
{
    public string targetTag = "KeySamochod"; // tag klocka (klucza)
    public float snapDelay = 0.5f;
    public string sceneToLoad = "NazwaTwojejSceny"; // <- wpisz tu dok�adn� nazw� sceny

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            XRGrabInteractable grab = other.GetComponent<XRGrabInteractable>();
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (grab != null && rb != null)
            {
                // Wy��cz interakcj� i fizyk�
                grab.enabled = false;
                rb.isKinematic = true;

                // Snap do slotu
                other.transform.position = transform.position;
                other.transform.rotation = transform.rotation;

                // Przej�cie do sceny
                Invoke("LoadNextScene", snapDelay);
            }
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
