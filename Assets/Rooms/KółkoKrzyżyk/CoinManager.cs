using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public Transform coinSlot;   // Miejsce, gdzie gracz mo�e po�o�y� monet�
    public GameObject coinPrefab; // Prefab monety
    public GameObject ticTacToeBoard; // Plansza do gry
    private bool gameStarted = false; // Flaga sprawdzaj�ca, czy gra si� ju� rozpocz�a

    void Start()
    {
        ticTacToeBoard.SetActive(false); // Plansza jest na pocz�tku ukryta
    }

    void Update()
    {
        // Sprawdzamy, czy gracz po�o�y� monet�
        if (!gameStarted && coinSlot.childCount > 0)
        {
            Destroy(coinSlot.GetChild(0).gameObject); // Usuwamy monet� po jej po�o�eniu
            Debug.Log("Moneta po�o�ona, zaczynamy gr�...");
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;
        ticTacToeBoard.SetActive(true); // Pokazujemy plansz�
        Debug.Log("Plansza zosta�a uruchomiona");
        FindObjectOfType<TicTacToeGame>().StartAI(); // Rozpoczynamy gr� z AI (k�ko)
    }
}
