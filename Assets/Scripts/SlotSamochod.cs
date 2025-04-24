using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SlotSamochod : MonoBehaviour
{
    public string targetTag = "KeySamochod"; // tag klocka (klucza)
    public float snapDelay = 0.5f;
    public string sceneToLoad = "NazwaTwojejSceny"; // <- wpisz tu dok³adn¹ nazwê sceny

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            XRGrabInteractable grab = other.GetComponent<XRGrabInteractable>();
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (grab != null && rb != null)
            {
                // Wy³¹cz interakcjê i fizykê
                grab.enabled = false;
                rb.isKinematic = true;

                // Snap do slotu
                other.transform.position = transform.position;
                other.transform.rotation = transform.rotation;

                // Przejœcie do sceny
                Invoke("LoadNextScene", snapDelay);
            }
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
