using System.Collections;
using UnityEngine;
using TMPro;  // Jeœli u¿ywasz TextMeshPro

public class CupGameVR : MonoBehaviour
{
    public GameObject[] cups;  // Kubki (3 kubki)
    public GameObject ball;    // Pi³eczka
    public TMP_Text resultText;    // Tekst wynikowy (zmiana na TextMeshPro)
    public Transform[] slots;  // Sloty (puste miejsca, do których trafiaj¹ kubki)

    private int ballPosition;  // Pozycja pi³eczki (0, 1, 2)
    private Vector3[] initialPositions;  // Pocz¹tkowe pozycje kubków

    void Start()
    {
        initialPositions = new Vector3[cups.Length];
        ShuffleCups();
        resultText.text = "";  // Na pocz¹tku brak wyniku
    }

    // Funkcja do mieszania kubków
    void ShuffleCups()
    {
        ballPosition = Random.Range(0, 3);  // Losowa pozycja pi³eczki

        // Pi³eczka staje siê dzieckiem kubka, który j¹ zawiera
        ball.transform.SetParent(cups[ballPosition].transform);

        // Ustawiamy pi³eczkê w odpowiedniej lokalnej pozycji wzglêdem kubka
        ball.transform.localPosition = new Vector3(0, 0.5f, 0);  // Pi³eczka pod kubkiem

        // Zapisujemy pocz¹tkowe pozycje kubków
        for (int i = 0; i < cups.Length; i++)
        {
            initialPositions[i] = cups[i].transform.position;
        }

        // Losowe mieszanie kubków
        StartCoroutine(MixCups());
    }

    // Coroutine do mieszania kubków
    IEnumerator MixCups()
    {
        float timeToShuffle = 2f;  // Czas mieszania kubków
        float elapsedTime = 0f;

        // Mieszanie kubków poprzez przesuwanie ich miêdzy slotami
        Vector3[] targetPositions = new Vector3[cups.Length];

        // Losujemy sloty, do których maj¹ trafiæ kubki
        for (int i = 0; i < cups.Length; i++)
        {
            targetPositions[i] = slots[Random.Range(0, slots.Length)].position;
        }

        // Mieszamy kubki przez okreœlony czas
        while (elapsedTime < timeToShuffle)
        {
            for (int i = 0; i < cups.Length; i++)
            {
                // P³ynne przesuwanie kubków za pomoc¹ Lerp
                cups[i].transform.position = Vector3.Lerp(cups[i].transform.position, targetPositions[i], elapsedTime / timeToShuffle);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Po zakoñczeniu mieszania ustawiamy koñcow¹ pozycjê kubków
        for (int i = 0; i < cups.Length; i++)
        {
            cups[i].transform.position = targetPositions[i];
        }
    }

    // Funkcja wywo³ywana po wykryciu dotkniêcia przez Poke Interactor
    public void OnCupPoked(int cupIndex)
    {
        // Sprawdzamy, czy gracz wybra³ prawid³owy kubek
        if (cupIndex == ballPosition)
        {
            resultText.text = "WIN!";  // Wyœwietl wynik
        }
        else
        {
            resultText.text = "Spróbuj ponownie!";  // Gracz wybra³ z³y kubek
        }

        // Mieszamy kubki po ka¿dej rundzie
        StartCoroutine(RestartGame());
    }

    // Restart gry po zakoñczeniu
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2f);  // Czekamy 2 sekundy
        ShuffleCups();
    }
}
