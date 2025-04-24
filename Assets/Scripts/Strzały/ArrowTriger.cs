using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    public Animator arrowAnimator; // Animator strza�y
    private Arrow arrowScript; // Referencja do skryptu Arrow

    void Start()
    {
        arrowScript = FindObjectOfType<Arrow>(); // Lub przypisz r�cznie w Inspectorze
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            arrowAnimator.SetTrigger("OpenStrza�y");

            if (arrowScript != null)
            {
                arrowScript.PlaySound(); // Uruchamia d�wi�k tylko przy wej�ciu
            }
        }
    }
}
