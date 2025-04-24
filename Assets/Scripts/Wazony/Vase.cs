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

        // Dodajemy AudioSource je�li go nie ma
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1.0f; // 3D d�wi�k, opcjonalnie
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

        // Odtwarzamy d�wi�k pot�uczenia
        if (breakSound != null)
        {
            audioSource.PlayOneShot(breakSound);
       }

        // Tworzymy model rozbitego wazonu
        if (brokenVasePrefab != null)
        {
            Instantiate(brokenVasePrefab, transform.position, transform.rotation);
        }

        // Zamiast od razu usuwa�, czekamy a� d�wi�k si� sko�czy
        Destroy(gameObject, breakSound.length);

        // Powiadamiamy VaseManagera
        vaseManager.VaseDestroyed();
    }
}
