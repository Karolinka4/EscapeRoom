using UnityEngine;

public class WallCollisionDetector : MonoBehaviour
{
    [Header("Ustawienia")]
    [SerializeField] private LayerMask wallsLayer; // Warstwa "Walls"
    [SerializeField] private AudioClip collisionSound; // DŸwiêk kolizji (opcjonalnie)

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Jeœli nie ma komponentu AudioSource, dodaj go automatycznie
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // SprawdŸ czy kolizja jest ze œcian¹ na warstwie "Walls" LUB ma tag "Wall"
        if (IsWall(collision.gameObject))
        {
            Debug.Log("Uderzono w œcianê: " + collision.gameObject.name);

            // Odtwórz dŸwiêk jeœli jest przypisany
            if (collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }
        }
    }

    private bool IsWall(GameObject obj)
    {
        // SprawdŸ warstwê ORAZ tag dla pewnoœci
        return (obj.layer == LayerMask.NameToLayer("Walls")) || obj.CompareTag("Wall");
    }
}