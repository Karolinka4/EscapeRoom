using UnityEngine;

public class PieceController : MonoBehaviour
{
    private BoardManager boardManager;
    private bool isBeingDragged = false;
    private Vector3 offset;

    void Start()
    {
        boardManager = FindObjectOfType<BoardManager>();
    }

    void OnMouseDown()
    {
        if ((boardManager.IsWhiteTurn() && gameObject.CompareTag("WhiteChecker")) ||
            (!boardManager.IsWhiteTurn() && gameObject.CompareTag("BlackChecker")))
        {
            isBeingDragged = true;
            offset = transform.position - Camera.main.WorldToScreenPoint(transform.position);
        }
    }

    void OnMouseDrag()
    {
        if (isBeingDragged)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, offset.z);
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
        }
    }

    void OnMouseUp()
    {
        isBeingDragged = false;
        // Sprawdzenie, czy pionek trafi³ na poprawne pole
        // Tutaj mo¿esz dodaæ logikê sprawdzania poprawnoœci ruchu
        boardManager.EndTurn();
    }
}
