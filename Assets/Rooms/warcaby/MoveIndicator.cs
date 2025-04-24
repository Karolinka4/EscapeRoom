using UnityEngine;

public class MoveIndicator : MonoBehaviour
{
    private Piece selectedPiece;

    // Funkcja do ustawienia pionka, który ma zostaæ przesuniêty
    public void SetMovePosition(Piece piece)
    {
        selectedPiece = piece;
    }

    private void OnMouseDown()
    {
        if (selectedPiece != null)
        {
            // Zmieniamy pozycjê pionka na slot, na który klikniêto
            Vector2Int newPos = new Vector2Int((int)transform.position.x, (int)transform.position.z);
            Debug.Log("Klikniêto slot: " + newPos); // Debugowanie, sprawdŸ, czy slot jest wykrywany
            selectedPiece.SetPosition(newPos); // Przesuniêcie pionka na slot
            Destroy(gameObject); // Usuwamy slot
        }
    }
}
