using UnityEngine;

public class ArrowKolce : MonoBehaviour
{
    public Animator arrowAnimator; // Animator strza³

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Wykrywa gracza
        {
            arrowAnimator.SetTrigger("OpenKolce"); // Uruchamia animacjê
        }
    }
}
