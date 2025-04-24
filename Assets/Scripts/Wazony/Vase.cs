using UnityEngine;

public class Vase : MonoBehaviour
{
    public GameObject brokenVasePrefab;
    public AudioClip breakSound;
    private VaseManager vaseManager;
    private bool isBroken = false;

    private AudioSource audioSource;

    void Start()
    {
        vaseManager = FindObjectOfType<VaseManager>();

        // Dodajemy AudioSource jeœli go nie ma
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1.0f; // 3D dŸwiêk, opcjonalnie
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isBroken && (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Ground")))
        {
            BreakVase();
        }
    }

    void BreakVase()
    {
        isBroken = true;

        // Odtwarzamy dŸwiêk pot³uczenia
        if (breakSound != null)
        {
            audioSource.PlayOneShot(breakSound);
       }

        // Tworzymy model rozbitego wazonu
        if (brokenVasePrefab != null)
        {
            Instantiate(brokenVasePrefab, transform.position, transform.rotation);
        }

        // Zamiast od razu usuwaæ, czekamy a¿ dŸwiêk siê skoñczy
        Destroy(gameObject, breakSound.length);

        // Powiadamiamy VaseManagera
        vaseManager.VaseDestroyed();
    }
}
