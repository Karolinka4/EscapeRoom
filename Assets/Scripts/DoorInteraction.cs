using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using System.Collections;

public class DoorInteraction : MonoBehaviour
{
    public GameObject fadePanel;
    public GameObject handle;
    public float fadeDuration = 1.5f;
    public string targetScene = "Sceneria3";

    private bool isDoorOpened = false;
    private XRGrabInteractable grabInteractable;
    private bool isGrabbed = false;

    private void Start()
    {
        if (fadePanel != null)
        {
            CanvasGroup canvasGroup = fadePanel.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0f;
            }
        }

        // Inicjalizacja komponentu XRGrabInteractable z klamki
        if (handle != null)
        {
            grabInteractable = handle.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                // Zaktualizowana obs³uga zdarzeñ
                grabInteractable.selectEntered.AddListener(OnGrabbed);  // Poprawiona wersja
                grabInteractable.selectExited.AddListener(OnReleased); // Poprawiona wersja
            }
            else
            {
                Debug.LogError("Brak komponentu XRGrabInteractable na klamce!");
            }
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)  // Zmieniony argument
    {
        isGrabbed = true;
    }

    private void OnReleased(SelectExitEventArgs args)  // Zmieniony argument
    {
        isGrabbed = false;
    }

    private void Update()
    {
        // Sprawdzamy czy klamka jest aktualnie z³apana
        if (isGrabbed && !isDoorOpened)
        {
            // U¿ywamy lokalnej rotacji (uwzglêdnia hierarchiê GameObjectów)
            float doorRotationY = transform.localEulerAngles.y;

            // Sprawdzamy czy drzwi zosta³y otwarte przynajmniej 45 stopni
            // Uwzglêdniamy "zawijanie" k¹tów Eulera (np. 350 stopni to -10)
            float normalizedAngle = doorRotationY > 180f ? doorRotationY - 360f : doorRotationY;

            if (Mathf.Abs(normalizedAngle) > 45f)
            {
                isDoorOpened = true;
                StartCoroutine(FadeAndLoadScene());
            }
        }
    }

    private IEnumerator FadeAndLoadScene()
    {
        if (fadePanel != null)
        {
            CanvasGroup canvasGroup = fadePanel.GetComponent<CanvasGroup>();
            float timer = 0f;

            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
                yield return null;
            }

            SceneManager.LoadScene(targetScene);
        }
    }
}
