using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFaderTrigger : MonoBehaviour
{
    [Header("Fade")]
    public CanvasGroup fadeCanvasGroup;         // przypisz swój czarny Canvas z CanvasGroup
    public float fadeDuration = 1f;

    [Header("Scena docelowa")]
    public string targetSceneName = "NazwaTwojejSceny";  // <- wpisz dok³adnie jak w Build Settings

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(FadeAndLoadScene());
        }
    }

    private IEnumerator FadeAndLoadScene()
    {
        float t = 0f;

        // Fade to black
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }

        // Przejœcie do nowej sceny
        SceneManager.LoadScene(targetSceneName);
    }
}
