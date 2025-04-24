// kod odpowiadaj�cy za wejscie gracza w pusty obiekt by wy�wietli� sie inny obiekt (ma�y pok�j w Sfinksie)
using UnityEngine;

public class ObjectSpawner : MonoBehaviour

{
    public GameObject prefab; // Przypisz prefab w Inspectorze
    private GameObject spawnedObject;

    private void OnTriggerEnter(Collider other)
    {
        if (spawnedObject == null) // Sprawdza, czy prefab ju� nie zosta� stworzony
        {
            spawnedObject = Instantiate(prefab, transform.position, transform.rotation);
            spawnedObject.transform.localScale = transform.localScale; // Zachowuje skal� obiektu
        }
    }
}
