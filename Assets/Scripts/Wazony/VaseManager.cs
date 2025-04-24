using UnityEngine;

public class VaseManager : MonoBehaviour
{
    public GameObject winElement; // Twój w³asny element do pokazania po rozbiciu wszystkich wazonów
    private int totalVases;
    private int destroyedVases = 0;

    void Start()
    {
        totalVases = GameObject.FindGameObjectsWithTag("Vase").Length;
        if (winElement != null) winElement.SetActive(false); // Ukryj element na pocz¹tku
    }

    public void VaseDestroyed()
    {
        destroyedVases++;
        if (destroyedVases >= totalVases)
        {
            Debug.Log("WIN!");
            if (winElement != null) winElement.SetActive(true); // Pokazuje Twój element, gdy wszystkie wazony s¹ zniszczone
        }
    }
}
