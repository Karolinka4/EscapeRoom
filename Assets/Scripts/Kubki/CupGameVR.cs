using System.Collections;
using UnityEngine;
using TMPro;  // Je�li u�ywasz TextMeshPro

public class CupGameVR : MonoBehaviour
{
    public GameObject[] cups;  // Kubki (3 kubki)
    public GameObject ball;    // Pi�eczka
    public TMP_Text resultText;    // Tekst wynikowy (zmiana na TextMeshPro)
    public Transform[] slots;  // Sloty (puste miejsca, do kt�rych trafiaj� kubki)

    private int ballPosition;  // Pozycja pi�eczki (0, 1, 2)
    private Vector3[] initialPositions;  // Pocz�tkowe pozycje kubk�w

    void Start()
    {
        initialPositions = new Vector3[cups.Length];
        ShuffleCups();
        resultText.text = "";  // Na pocz�tku brak wyniku
    }

    // Funkcja do mieszania kubk�w
    void ShuffleCups()
    {
        ballPosition = Random.Range(0, 3);  // Losowa pozycja pi�eczki

        // Pi�eczka staje si� dzieckiem kubka, kt�ry j� zawiera
        ball.transform.SetParent(cups[ballPosition].transform);

        // Ustawiamy pi�eczk� w odpowiedniej lokalnej pozycji wzgl�dem kubka
        ball.transform.localPosition = new Vector3(0, 0.5f, 0);  // Pi�eczka pod kubkiem

        // Zapisujemy pocz�tkowe pozycje kubk�w
        for (int i = 0; i < cups.Length; i++)
        {
            initialPositions[i] = cups[i].transform.position;
        }

        // Losowe mieszanie kubk�w
        StartCoroutine(MixCups());
    }

    // Coroutine do mieszania kubk�w
    IEnumerator MixCups()
    {
        float timeToShuffle = 2f;  // Czas mieszania kubk�w
        float elapsedTime = 0f;

        // Mieszanie kubk�w poprzez przesuwanie ich mi�dzy slotami
        Vector3[] targetPositions = new Vector3[cups.Length];

        // Losujemy sloty, do kt�rych maj� trafi� kubki
        for (int i = 0; i < cups.Length; i++)
        {
            targetPositions[i] = slots[Random.Range(0, slots.Length)].position;
        }

        // Mieszamy kubki przez okre�lony czas
        while (elapsedTime < timeToShuffle)
        {
            for (int i = 0; i < cups.Length; i++)
            {
                // P�ynne przesuwanie kubk�w za pomoc� Lerp
                cups[i].transform.position = Vector3.Lerp(cups[i].transform.position, targetPositions[i], elapsedTime / timeToShuffle);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Po zako�czeniu mieszania ustawiamy ko�cow� pozycj� kubk�w
        for (int i = 0; i < cups.Length; i++)
        {
            cups[i].transform.position = targetPositions[i];
        }
    }

    // Funkcja wywo�ywana po wykryciu dotkni�cia przez Poke Interactor
    public void OnCupPoked(int cupIndex)
    {
        // Sprawdzamy, czy gracz wybra� prawid�owy kubek
        if (cupIndex == ballPosition)
        {
            resultText.text = "WIN!";  // Wy�wietl wynik
        }
        else
        {
            resultText.text = "Spr�buj ponownie!";  // Gracz wybra� z�y kubek
        }

        // Mieszamy kubki po ka�dej rundzie
        StartCoroutine(RestartGame());
    }

    // Restart gry po zako�czeniu
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2f);  // Czekamy 2 sekundy
        ShuffleCups();
    }
}
