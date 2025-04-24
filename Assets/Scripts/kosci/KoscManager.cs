using UnityEngine;
using System.Collections;
using TMPro;

public class KoscManager : MonoBehaviour
{
    public Dice[] playerDice;
    public Dice[] npcDice;
    public Transform playerThrowPosition; // Pozycja rzutu gracza
    public Transform npcThrowPosition; // Pozycja rzutu NPC
    public GameObject dicePrefab;
    public TMP_Text resultText;

    private void Start()
    {
        StartCoroutine(GameSequence());
    }

    IEnumerator GameSequence()
    {
        // NPC rzuca ko�ci
        SpawnAndThrowDice(npcDice, npcThrowPosition);
        yield return new WaitForSeconds(2); // Czas na zatrzymanie NPC

        // Gracz rzuca ko�ci
        SpawnAndThrowDice(playerDice, playerThrowPosition);
        yield return new WaitForSeconds(2); // Czas na zatrzymanie gracza

        // Sprawdzenie wyniku
        int npcTotal = CalculateTotal(npcDice);
        int playerTotal = CalculateTotal(playerDice);

        if (playerTotal > npcTotal)
            resultText.text = "Gratulacje, wygra�e�!";
        else if (playerTotal < npcTotal)
            resultText.text = "Niestety, przegra�e�...";
        else
            resultText.text = "Remis!";
    }

    void SpawnAndThrowDice(Dice[] diceArray, Transform throwPosition)
    {
        for (int i = 0; i < diceArray.Length; i++)
        {
            // Tworzenie ko�ci na wyznaczonej pozycji
            GameObject diceObject = Instantiate(dicePrefab, throwPosition.position, Random.rotation);
            Rigidbody rb = diceObject.GetComponent<Rigidbody>();
            rb.AddForce(Random.insideUnitSphere * 5f + Vector3.up * 10f, ForceMode.Impulse); // Rzucenie ko�ci
            diceArray[i] = diceObject.GetComponent<Dice>();
        }
    }

    int CalculateTotal(Dice[] diceArray)
    {
        int total = 0;
        foreach (var die in diceArray)
        {
            total += die.Result;
        }
        return total;
    }
}
