using UnityEngine;

public class Piece : MonoBehaviour
{
    public Vector2Int boardPosition; // Pozycja pionka na planszy
    public bool isWhite; // Czy pionek jest bia³y?
    public GameObject moveSlotPrefab; // Prefab dla slotu ruchu

    // Ustawienie pozycji pionka na planszy
    public void SetPosition(Vector2Int newPos)
    {
        boardPosition = newPos;
        transform.position = new Vector3(newPos.x, 0.5f, newPos.y); // Przemieszczenie pionka
        Debug.Log("Pionek przeniesiony na: " + newPos);  // Debugowanie
    }


    // Pokazanie dostêpnych ruchów dla pionka
    public void ShowAvailableMoves()
    {
        Vector2Int[] possibleMoves = {
        new Vector2Int(boardPosition.x + 1, boardPosition.y + 1),
        new Vector2Int(boardPosition.x - 1, boardPosition.y + 1)
    };

        foreach (Vector2Int move in possibleMoves)
        {
            // SprawdŸ, czy ruch jest w granicach planszy
            if (move.x >= 0 && move.x < 8 && move.y >= 0 && move.y < 8)
            {
                GameObject slot = Instantiate(moveSlotPrefab, new Vector3(move.x, 0.1f, move.y), Quaternion.identity);
                slot.GetComponent<MoveIndicator>().SetMovePosition(this); // Przypisanie pionka do slotu
                Debug.Log("Slot wygenerowany na: " + move); // Debugowanie
            }
        }
    }

}
