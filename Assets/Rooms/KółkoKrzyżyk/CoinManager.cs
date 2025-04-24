using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public Transform coinSlot;   // Miejsce, gdzie gracz mo¿e po³o¿yæ monetê
    public GameObject coinPrefab; // Prefab monety
    public GameObject ticTacToeBoard; // Plansza do gry
    private bool gameStarted = false; // Flaga sprawdzaj¹ca, czy gra siê ju¿ rozpoczê³a

    void Start()
    {
        ticTacToeBoard.SetActive(false); // Plansza jest na pocz¹tku ukryta
    }

    void Update()
    {
        // Sprawdzamy, czy gracz po³o¿y³ monetê
        if (!gameStarted && coinSlot.childCount > 0)
        {
            Destroy(coinSlot.GetChild(0).gameObject); // Usuwamy monetê po jej po³o¿eniu
            Debug.Log("Moneta po³o¿ona, zaczynamy grê...");
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;
        ticTacToeBoard.SetActive(true); // Pokazujemy planszê
        Debug.Log("Plansza zosta³a uruchomiona");
        FindObjectOfType<TicTacToeGame>().StartAI(); // Rozpoczynamy grê z AI (kó³ko)
    }
}
