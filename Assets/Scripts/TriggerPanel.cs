using UnityEngine;

public class TriggerPanel : MonoBehaviour
{
    public GameObject panelToShow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // upewnij siê, ¿e gracz ma tag "Player"
        {
            if (panelToShow != null)
                panelToShow.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (panelToShow != null)
                panelToShow.SetActive(false);
        }
    }
}
