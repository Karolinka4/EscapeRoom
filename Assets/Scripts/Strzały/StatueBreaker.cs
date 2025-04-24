using UnityEngine;

public class StatueBreaker : MonoBehaviour
{
    public GameObject brokenStatuePrefab; // Prefab rozbitego posągu
    public Animator arrowAnimator; // Animator od strzał
    public AudioClip breakSound; // Dźwięk rozbicia
    public Arrow arrowScript; // Referencja do obiektu strzały
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stone")) // Jeśli kamień uderzył
        {
            BreakStatue(); // Przy pierwszym uderzeniu zamieniamy posąg na rozbity
        }
    }

    void BreakStatue()
    {
        // Odtwarzamy dźwięk stłuczenia
        if (breakSound != null)
        {
            AudioSource.PlayClipAtPoint(breakSound, transform.position);
        }
        // Resetujemy animację od razu po zniszczeniu
        arrowAnimator.Rebind(); // Resetuje animację do stanu początkowego
        arrowAnimator.Update(0f); // Wymusza natychmiastowe zaktualizowanie animacji
        arrowAnimator.enabled = false; // Wyłącza animator

        // Tworzymy nowy, rozbity posąg
        Instantiate(brokenStatuePrefab, transform.position, transform.rotation);

        // Usuwamy stary posąg
        Destroy(gameObject);
    }
}