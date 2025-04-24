using UnityEngine;

public class WallCollisionDetector : MonoBehaviour
{
    [Header("Ustawienia")]
    [SerializeField] private LayerMask wallsLayer; // Warstwa "Walls"
    [SerializeField] private AudioClip collisionSound; // D�wi�k kolizji (opcjonalnie)

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Je�li nie ma komponentu AudioSource, dodaj go automatycznie
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Sprawd� czy kolizja jest ze �cian� na warstwie "Walls" LUB ma tag "Wall"
        if (IsWall(collision.gameObject))
        {
            Debug.Log("Uderzono w �cian�: " + collision.gameObject.name);

            // Odtw�rz d�wi�k je�li jest przypisany
            if (collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }
        }
    }

    private bool IsWall(GameObject obj)
    {
        // Sprawd� warstw� ORAZ tag dla pewno�ci
        return (obj.layer == LayerMask.NameToLayer("Walls")) || obj.CompareTag("Wall");
    }
}