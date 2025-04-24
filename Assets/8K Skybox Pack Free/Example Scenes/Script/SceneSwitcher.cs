using UnityEngine;
using UnityEngine.SceneManagement; // Dodaj t� lini�, aby m�c prze��cza� sceny

public class SceneSwitcher : MonoBehaviour
{
    public string nextSceneName; // Nazwa sceny do kt�rej chcesz przej��

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Upewnij si�, �e gracz ma tag "Player"
        {
            Debug.Log("Gracz wszed� w trigger � zmiana sceny!");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
