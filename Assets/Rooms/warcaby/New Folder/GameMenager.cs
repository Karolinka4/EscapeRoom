using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoardManager boardManager;  // Referencja do BoardManager
    public BotAI botAI;  // Referencja do AI bota

    void Update()
    {
        // Sprawdzamy, czy to tura bia�ych (bota)
        if (boardManager.IsWhiteTurn())
        {
            // Sprawdzamy, czy bot jeszcze nie wykona� ruchu
            if (!botAI.HasMadeMove())
            {
                Debug.Log("Bot wykonuje ruch");
                botAI.MakeMove();  // Wywo�ujemy funkcj� bota
            }
        }
        else
        {
            Debug.Log("Czekanie na ruch gracza");
        }
    }
}
