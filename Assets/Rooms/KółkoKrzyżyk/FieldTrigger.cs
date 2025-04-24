using UnityEngine;

public class FieldTrigger : MonoBehaviour
{
    public TicTacToeGame ticTacToeGame; // Skrypt gry

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy to gracz
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz wszed� na pole!");
            // Okre�lamy, na kt�rym polu si� znajduje (np. poprzez tag lub nazw� obiektu)
            int index = GetFieldIndexBasedOnPosition(); // To jest metoda, kt�r� musisz stworzy�, by zwr�ci� odpowiedni indeks

            // Wywo�ujemy metod� PlayerMove na odpowiednim indeksie
            ticTacToeGame.PlayerMove(index);
        }
    }

    private int GetFieldIndexBasedOnPosition()
    {
        // Implementacja mapowania pozycji do indeks�w
        // Mo�e by� prosta, je�li masz dobrze ustawion� hierarchi� obiekt�w na scenie
        // np. mo�esz obliczy� pozycj� w zale�no�ci od wsp�rz�dnych
        return 0;  // Zmieniaj to na odpowiedni indeks
    }
}
