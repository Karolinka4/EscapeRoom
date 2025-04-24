using UnityEngine;

public class Card : MonoBehaviour
{
    public string cardID;
    public MemoryGame gameManager;

    public Material grayMaterial;
    public Material revealMaterial;

    private bool isFlipped = false;
    private Renderer rend;

    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        rend.material = new Material(grayMaterial); // Unikalna instancja
    }

    public void OnSelected()
    {
        if (!isFlipped)
        {
            Debug.Log("Klikniêto kartê: " + cardID);
            FlipCard();
            gameManager.OnCardFlipped(gameObject, cardID);
        }
    }

    public void FlipCard()
    {
        isFlipped = !isFlipped;

        if (isFlipped)
        {
            Debug.Log($"[Flip] Karta {cardID} zosta³a ODKRYTA");
            rend.material = revealMaterial;
        }
        else
        {
            Debug.Log($"[Flip] Karta {cardID} zosta³a ZAKRYTA");
            rend.material = grayMaterial;
        }
    }

}
