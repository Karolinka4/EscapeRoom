using UnityEngine;

public class FieldTrigger : MonoBehaviour
{
    public TicTacToeGame ticTacToeGame; // Skrypt gry

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy to gracz
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz wszed³ na pole!");
            // Okreœlamy, na którym polu siê znajduje (np. poprzez tag lub nazwê obiektu)
            int index = GetFieldIndexBasedOnPosition(); // To jest metoda, któr¹ musisz stworzyæ, by zwróciæ odpowiedni indeks

            // Wywo³ujemy metodê PlayerMove na odpowiednim indeksie
            ticTacToeGame.PlayerMove(index);
        }
    }

    private int GetFieldIndexBasedOnPosition()
    {
        // Implementacja mapowania pozycji do indeksów
        // Mo¿e byæ prosta, jeœli masz dobrze ustawion¹ hierarchiê obiektów na scenie
        // np. mo¿esz obliczyæ pozycjê w zale¿noœci od wspó³rzêdnych
        return 0;  // Zmieniaj to na odpowiedni indeks
    }
}
