using UnityEngine;

public class CheckerManager : MonoBehaviour
{
    public SlotChecker[] slots; // Lista przechowująca wszystkie sloty na planszy
    public GameObject winText;  // UI z napisem WIN (ukryte na starcie)

    private void Start()
    {
        winText.SetActive(false); // Ukrywamy "WIN-obiekt wygranej" na początku gry
    }

    public void CheckWin()
    {
        foreach (SlotChecker slot in slots)
        {
            if (!slot.IsCorrect())
            {
                return; // Jeśli chociaż jeden slot jest błędny, nic się nie dzieje
            }
        }

        // Jeśli wszystkie są poprawne → WYGRANA!
        winText.SetActive(true);
    }
}
