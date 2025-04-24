using UnityEngine;

public class BotAI : MonoBehaviour
{
    public BoardManager boardManager;  // Referencja do BoardManager
    public GameObject[] whiteCheckers;  // Bia�e pionki bota
    private bool hasMadeMove = false;

    void Start()
    {
        // Debugowanie: Sprawd�my, ile pionk�w ma bot
        whiteCheckers = GameObject.FindGameObjectsWithTag("CheckerWhite");
        Debug.Log("Znaleziono " + whiteCheckers.Length + " bia�ych pionk�w.");

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
            Debug.Log("Bot wybra� pionek: " + checker.name);

            // Wybieramy now� pozycj� dla pionka
            Vector3 targetPosition = checker.transform.position + new Vector3(1, 0, 1);
            Debug.Log("Docelowa pozycja: " + targetPosition);

            // Poruszamy pionkiem
            checker.transform.position = Vector3.Lerp(checker.transform.position, targetPosition, Time.deltaTime * 2);

            // Kiedy pionek osi�gnie cel, ko�czymy tur�
            if (Vector3.Distance(checker.transform.position, targetPosition) < 0.1f)
            {
                hasMadeMove = true;
                boardManager.EndTurn();  // Zako�czenie tury
                Debug.Log("Bot zako�czy� ruch.");
            }
        }
        else
        {
            Debug.LogError("Bot nie ma pionk�w do poruszenia.");
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
