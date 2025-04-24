using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject[] whiteCheckers;  // Pionki bia�e - bot
    public GameObject[] blackCheckers;  // Pionki czarne - gracz

    private bool isWhiteTurn = false;  // Bot zaczyna gr� (bia�e pionki)

    void Start()
    {
        // Inicjalizacja pionk�w na planszy
        whiteCheckers = GameObject.FindGameObjectsWithTag("CheckerWhite");
        blackCheckers = GameObject.FindGameObjectsWithTag("CheckerBlack");

        Debug.Log("Bia�e pionki: " + whiteCheckers.Length);
        Debug.Log("Czarne pionki: " + blackCheckers.Length);
    }

    public void EndTurn()
    {
        // Zmiana tury
        isWhiteTurn = !isWhiteTurn;

        // Debugowanie - sprawdzenie, kt�ra tura jest aktywna
        Debug.Log("Teraz jest tura: " + (isWhiteTurn ? "Bia�ych" : "Czarnych"));
    }

    public bool IsWhiteTurn()
    {
        return isWhiteTurn;  // Zwr��, czy to tura bia�ych (bota)
    }
}
