using UnityEngine;

public class GameController : MonoBehaviour
{
    private Piece selectedPiece;

    private void OnMouseDown()
    {
        Piece piece = GetComponent<Piece>();
        if (piece != null)
        {
            // Je�li wcze�niej by� wybrany pionek, usu� poprzednie sloty
            if (selectedPiece != null)
            {
                DestroySlots();
            }

            // Ustaw wybrany pionek
            selectedPiece = piece;

            // Wy�wietl dost�pne ruchy dla wybranego pionka
            selectedPiece.ShowAvailableMoves();
        }
    }

    // Funkcja do usuwania wcze�niejszych slot�w (np. je�li gracz wybierze inny pionek)
    private void DestroySlots()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("MoveSlot");
        foreach (GameObject slot in slots)
        {
            Destroy(slot);
        }
    }
}
