using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIPlayer : MonoBehaviour
{
    private Piece selectedPiece;

    // ZnajdŸ dostêpne pionki AI (czarne)
    private List<Piece> FindAvailablePieces()
    {
        List<Piece> aiPieces = new List<Piece>();
        foreach (Piece piece in FindObjectsOfType<Piece>())
        {
            if (!piece.isWhite) // AI gra czarnymi
            {
                aiPieces.Add(piece);
            }
        }
        return aiPieces;
    }

    // Wykonaj losowy ruch dla AI
    public void MakeMove()
    {
        List<Piece> aiPieces = FindAvailablePieces();
        if (aiPieces.Count > 0)
        {
            Piece piece = aiPieces[Random.Range(0, aiPieces.Count)];
            piece.ShowAvailableMoves();
            // Implementacja losowego ruchu (np. wybór slotu i przemieszczanie pionka)
        }
    }
}
