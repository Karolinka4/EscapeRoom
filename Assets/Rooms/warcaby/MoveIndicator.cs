using UnityEngine;

public class MoveIndicator : MonoBehaviour
{
    private Piece selectedPiece;

    // Funkcja do ustawienia pionka, kt�ry ma zosta� przesuni�ty
    public void SetMovePosition(Piece piece)
    {
        selectedPiece = piece;
    }

    private void OnMouseDown()
    {
        if (selectedPiece != null)
        {
            // Zmieniamy pozycj� pionka na slot, na kt�ry klikni�to
            Vector2Int newPos = new Vector2Int((int)transform.position.x, (int)transform.position.z);
            Debug.Log("Klikni�to slot: " + newPos); // Debugowanie, sprawd�, czy slot jest wykrywany
            selectedPiece.SetPosition(newPos); // Przesuni�cie pionka na slot
            Destroy(gameObject); // Usuwamy slot
        }
    }
}
