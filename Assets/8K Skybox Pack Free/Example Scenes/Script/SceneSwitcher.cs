using UnityEngine;
using UnityEngine.SceneManagement; // Dodaj tê liniê, aby móc prze³¹czaæ sceny

public class SceneSwitcher : MonoBehaviour
{
    public string nextSceneName; // Nazwa sceny do której chcesz przejœæ

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Upewnij siê, ¿e gracz ma tag "Player"
        {
            Debug.Log("Gracz wszed³ w trigger – zmiana sceny!");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
