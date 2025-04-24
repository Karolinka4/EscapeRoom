using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarcabyGame
{
    public class CheckManager : MonoBehaviour
    {
        public void CheckWinCondition()
        {
            int playerCount = FindObjectsOfType<Piece>().Length;
            if (playerCount == 0)
            {
                Debug.Log("Game Over! Resetting...");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
