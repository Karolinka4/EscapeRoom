using UnityEngine;

public class BotAI : MonoBehaviour
{
    public BoardManager boardManager;  // Referencja do BoardManager
    public GameObject[] whiteCheckers;  // Bia³e pionki bota
    private bool hasMadeMove = false;

    void Start()
    {
        // Debugowanie: SprawdŸmy, ile pionków ma bot
        whiteCheckers = GameObject.FindGameObjectsWithTag("CheckerWhite");
        Debug.Log("Znaleziono " + whiteCheckers.Length + " bia³ych pionków.");

        if (boardManager == null)
        {
            Debug.LogError("BoardManager nie jest przypisany w BotAI!");
        }
    }

    public void MakeMove()
    {
        if (whiteCheckers.Length > 0)
        {
            // Wybieramy losowy pionek
            GameObject checker = whiteCheckers[Random.Range(0, whiteCheckers.Length)];
            Debug.Log("Bot wybra³ pionek: " + checker.name);

            // Wybieramy now¹ pozycjê dla pionka
            Vector3 targetPosition = checker.transform.position + new Vector3(1, 0, 1);
            Debug.Log("Docelowa pozycja: " + targetPosition);

            // Poruszamy pionkiem
            checker.transform.position = Vector3.Lerp(checker.transform.position, targetPosition, Time.deltaTime * 2);

            // Kiedy pionek osi¹gnie cel, koñczymy turê
            if (Vector3.Distance(checker.transform.position, targetPosition) < 0.1f)
            {
                hasMadeMove = true;
                boardManager.EndTurn();  // Zakoñczenie tury
                Debug.Log("Bot zakoñczy³ ruch.");
            }
        }
        else
        {
            Debug.LogError("Bot nie ma pionków do poruszenia.");
        }
    }

    public bool HasMadeMove()
    {
        return hasMadeMove;
    }

    public void ResetMoveFlag()
    {
        hasMadeMove = false;
    }
}
