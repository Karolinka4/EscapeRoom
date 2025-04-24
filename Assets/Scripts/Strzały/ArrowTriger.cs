using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    public Animator arrowAnimator; // Animator strza³y
    private Arrow arrowScript; // Referencja do skryptu Arrow

    void Start()
    {
        arrowScript = FindObjectOfType<Arrow>(); // Lub przypisz rêcznie w Inspectorze
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            arrowAnimator.SetTrigger("OpenStrza³y");

            if (arrowScript != null)
            {
                arrowScript.PlaySound(); // Uruchamia dŸwiêk tylko przy wejœciu
            }
        }
    }
}
