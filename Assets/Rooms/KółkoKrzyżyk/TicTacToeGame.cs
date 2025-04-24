using UnityEngine;

public class TicTacToeGame : MonoBehaviour
{
    public GameObject circlePrefab;  // Prefab dla "O" (kó³ko)
    public GameObject crossPrefab;   // Prefab dla "X" (krzy¿yk)
    public Transform[] boardPositions; // Pozycje na planszy (Empty GameObjects w Unity)

    private int[,] board = new int[3, 3]; // Plansza w formie tablicy 3x3
    private bool playerTurn = false; // Flaga, która mówi, czy teraz ruch gracza
    private bool gameOver = false; // Flaga, która mówi, czy gra siê skoñczy³a

    public void StartAI()
    {
        Debug.Log("Rozpoczynamy grê...");
        ResetBoard();  // Resetujemy planszê
        AI_Move();  // AI wykonuje pierwszy ruch
    }

    public void PlayerMove(int index)
    {
        if (gameOver || !playerTurn || board[index / 3, index % 3] != 0) return;

        board[index / 3, index % 3] = 1;
        Instantiate(crossPrefab, boardPositions[index].position, Quaternion.identity); // Po³o¿enie X
        playerTurn = false;

        if (CheckWin(1)) // Sprawdzamy, czy gracz wygra³
        {
            Debug.Log("Gracz wygra³!");
            SpawnReward();
            gameOver = true;
        }
        else
        {
            AI_Move(); // AI wykonuje nastêpny ruch
        }
    }

    void AI_Move()
    {
        if (gameOver) return;

        // AI wykonuje ruch w pierwszym wolnym polu
        for (int i = 0; i < 9; i++)
        {
            if (board[i / 3, i % 3] == 0)
            {
                board[i / 3, i % 3] = 2;
                Instantiate(circlePrefab, boardPositions[i].position, Quaternion.identity); // Po³o¿enie O
                break;
            }
        }

        if (CheckWin(2)) // Sprawdzamy, czy AI wygra³o
        {
            Debug.Log("AI wygra³o!");
            gameOver = true;
            return;
        }

        playerTurn = true; // Teraz gracz mo¿e wykonaæ ruch
    }

    bool CheckWin(int player)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) return true;
            if (board[0, i] == player && board[1, i] == player && board[2, i] == player) return true;
        }
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) return true;
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) return true;

        return false;
    }

    void SpawnReward()
    {
        // Po wygranej gracza pojawiaj¹ siê dwie monety
        Instantiate(Resources.Load("CoinPrefab"), new Vector3(-0.5f, 1, 0), Quaternion.identity);
        Instantiate(Resources.Load("CoinPrefab"), new Vector3(0.5f, 1, 0), Quaternion.identity);
    }

    void ResetBoard()
    {
        // Resetowanie planszy
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = 0;
            }
        }
        gameOver = false;

        // Usuwamy wszystkie symbole "X" i "O"
        GameObject[] crosses = GameObject.FindGameObjectsWithTag("Cross");
        GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");

        foreach (GameObject obj in crosses) Destroy(obj);
        foreach (GameObject obj in circles) Destroy(obj);
    }
}
