using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject[] whiteCheckers;  // Pionki bia³e - bot
    public GameObject[] blackCheckers;  // Pionki czarne - gracz

    private bool isWhiteTurn = false;  // Bot zaczyna grê (bia³e pionki)

    void Start()
    {
        // Inicjalizacja pionków na planszy
        whiteCheckers = GameObject.FindGameObjectsWithTag("CheckerWhite");
        blackCheckers = GameObject.FindGameObjectsWithTag("CheckerBlack");

        Debug.Log("Bia³e pionki: " + whiteCheckers.Length);
        Debug.Log("Czarne pionki: " + blackCheckers.Length);
    }

    public void EndTurn()
    {
        // Zmiana tury
        isWhiteTurn = !isWhiteTurn;

        // Debugowanie - sprawdzenie, która tura jest aktywna
        Debug.Log("Teraz jest tura: " + (isWhiteTurn ? "Bia³ych" : "Czarnych"));
    }

    public bool IsWhiteTurn()
    {
        return isWhiteTurn;  // Zwróæ, czy to tura bia³ych (bota)
    }
}
