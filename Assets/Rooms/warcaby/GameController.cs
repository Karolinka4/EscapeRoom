using UnityEngine;

public class GameController : MonoBehaviour
{
    private Piece selectedPiece;

    private void OnMouseDown()
    {
        Piece piece = GetComponent<Piece>();
        if (piece != null)
        {
            // Jeœli wczeœniej by³ wybrany pionek, usuñ poprzednie sloty
            if (selectedPiece != null)
            {
                DestroySlots();
            }

            // Ustaw wybrany pionek
            selectedPiece = piece;

            // Wyœwietl dostêpne ruchy dla wybranego pionka
            selectedPiece.ShowAvailableMoves();
        }
    }

    // Funkcja do usuwania wczeœniejszych slotów (np. jeœli gracz wybierze inny pionek)
    private void DestroySlots()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("MoveSlot");
        foreach (GameObject slot in slots)
        {
            Destroy(slot);
        }
    }
}
