// kod odpowiadaj¹cy za wejscie gracza w pusty obiekt by wyœwietli³ sie inny obiekt (ma³y pokój w Sfinksie)
using UnityEngine;

public class ObjectSpawner : MonoBehaviour

{
    public GameObject prefab; // Przypisz prefab w Inspectorze
    private GameObject spawnedObject;

    private void OnTriggerEnter(Collider other)
    {
        if (spawnedObject == null) // Sprawdza, czy prefab ju¿ nie zosta³ stworzony
        {
            spawnedObject = Instantiate(prefab, transform.position, transform.rotation);
            spawnedObject.transform.localScale = transform.localScale; // Zachowuje skalê obiektu
        }
    }
}
