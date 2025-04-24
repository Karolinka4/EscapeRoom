using UnityEngine;

public class VaseManager : MonoBehaviour
{
    public GameObject winElement; // Tw�j w�asny element do pokazania po rozbiciu wszystkich wazon�w
    private int totalVases;
    private int destroyedVases = 0;

    void Start()
    {
        totalVases = GameObject.FindGameObjectsWithTag("Vase").Length;
        if (winElement != null) winElement.SetActive(false); // Ukryj element na pocz�tku
    }

    public void VaseDestroyed()
    {
        destroyedVases++;
        if (destroyedVases >= totalVases)
        {
            Debug.Log("WIN!");
            if (winElement != null) winElement.SetActive(true); // Pokazuje Tw�j element, gdy wszystkie wazony s� zniszczone
        }
    }
}
