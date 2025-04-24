using System.Collections.Generic;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    public Animator drzwiAnimator;   // Animator od drzwi z trigerem "Open"
    public Animator glazAnimator;    // Animator g³azu (odpala siê po znalezieniu wszystkich par)

    private bool canClick = true;
    private List<GameObject> flippedCards = new List<GameObject>();
    private List<string> cardIdentifiers = new List<string>();

    private int totalPairs;
    private int foundPairs = 0;
    private bool isDoorAnimating = false;

    void Start()
    {
        totalPairs = GameObject.FindObjectsOfType<Card>().Length / 2;
    }

    public void OnCardFlipped(GameObject card, string identifier)
    {
        if (!canClick) return;

        flippedCards.Add(card);
        cardIdentifiers.Add(identifier);

        if (flippedCards.Count == 2)
        {
            canClick = false;
            Invoke(nameof(CheckMatch), 1f);
        }
    }

    private void CheckMatch()
    {
        if (cardIdentifiers[0] == cardIdentifiers[1])
        {
            Debug.Log("Match Found!");
            foundPairs++;

            if (foundPairs == totalPairs)
            {
                Debug.Log("Znaleziono wszystkie pary!");
                if (isDoorAnimating)
                {
                    drzwiAnimator.ResetTrigger("Open");
                    isDoorAnimating = false;
                }
                glazAnimator.SetTrigger("Start"); // upewnij siê, ¿e w animatorze g³azu jest trigger "Start"
            }
        }
        else
        {
            Debug.Log("No match – odwracam z powrotem");
            flippedCards[0].GetComponent<Card>().FlipCard();
            flippedCards[1].GetComponent<Card>().FlipCard();

            if (!isDoorAnimating && foundPairs == 0)
            {
                drzwiAnimator.SetTrigger("Open");
                isDoorAnimating = true;
            }
        }

        flippedCards.Clear();
        cardIdentifiers.Clear();
        canClick = true;
    }
}
