using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeSlotGame : MonoBehaviour
{
    public Transform slotTransformGracz;  // Slot gracza, do którego gracz wk³ada klocek
    public Transform slotTransformNpc;  // Slot NPC, do którego pojawi siê klocek NPC
    public GameObject npcCubePrefab;  // Prefab klocka NPC, który pojawi siê w slocie NPC
    public TextMeshProUGUI feedbackText;  // Tekst feedbacku dla gracza (np. "Brawo!", "Spróbuj ponownie")

    public GameObject[] playerCubes;  // Tablica prefabów klocków gracza (od 1 do 10)

    private int npcChoice = -1;     // Losowy wybór NPC
    private GameObject selectedCube = null; // Klocek wybrany przez gracza
    private GameObject npcCube = null; // Klocek NPC
    private bool isCubeInSlot = false; // Flaga, czy klocek jest w slocie

    void Start()
    {
        npcChoice = Random.Range(1, 11);  // Losowanie liczby przez NPC (od 1 do 10)
        Debug.Log("NPC wybra³ liczbê: " + npcChoice);  // Mo¿emy zobaczyæ, jak¹ liczbê wylosowa³ NPC
        feedbackText.text = ""; // Na pocz¹tku brak feedbacku
    }

    // Funkcja wywo³ywana po tym, jak gracz wybierze klocek i chce go umieœciæ
    public void OnCubeSelected(GameObject cube)
    {
        // Gracz wybra³ klocek, wiêc go przypisujemy
        selectedCube = cube;
        // Przemieszczamy klocek do slotu gracza
        MoveCubeToSlot();
    }

    // Funkcja przyci¹gaj¹ca klocek do slotu gracza
    void MoveCubeToSlot()
    {
        if (selectedCube != null && !isCubeInSlot)
        {
            // Przyci¹ganie klocka do slotu gracza przy pomocy interpolacji (Lerp)
            selectedCube.transform.position = Vector3.Lerp(selectedCube.transform.position, slotTransformGracz.position, Time.deltaTime * 5f);

            // Jeœli klocek jest wystarczaj¹co blisko slotu, uznajemy, ¿e trafi³ do slotu
            if (Vector3.Distance(selectedCube.transform.position, slotTransformGracz.position) < 0.1f)
            {
                selectedCube.transform.position = slotTransformGracz.position; // Dok³adne ustawienie klocka w slot
                isCubeInSlot = true;  // Ustawiamy flagê, ¿e klocek jest w slocie

                // Teraz po umieszczeniu klocka przez gracza, wyœwietlamy klocek NPC w jego slocie
                ShowNpcCube();
                // Sprawdzamy, czy gracz zgad³ liczbê
                CheckSlot();
            }
        }
    }

    // Funkcja, która pokazuje klocek NPC w slocie NPC
    void ShowNpcCube()
    {
        // Tworzymy prefab klocka NPC (jeœli jeszcze go nie mamy)
        if (npcCube == null)
        {
            npcCube = Instantiate(npcCubePrefab, slotTransformNpc.position, Quaternion.identity); // Tworzymy klocek NPC w slocie NPC
            TMP_Text npcText = npcCube.GetComponentInChildren<TMP_Text>(); // U¿ywamy TMP_Text zamiast TextMesh
            npcText.text = npcChoice.ToString();  // Przypisujemy tekst (cyfrê) do klocka NPC
        }
    }

    // Funkcja do sprawdzania, czy gracz zgad³
    void CheckSlot()
    {
        // Pobieramy cyfrê z klocka wybranego przez gracza
        int playerChoice = int.Parse(selectedCube.GetComponentInChildren<TMP_Text>().text);

        // Sprawdzamy, czy wybór gracza pasuje do wyboru NPC
        if (playerChoice == npcChoice)
        {
            feedbackText.text = "Brawo! Zgad³eœ!"; // Gracz zgad³
        }
        else
        {
            feedbackText.text = "Niestety, spróbuj ponownie."; // Gracz nie zgad³
        }

        // Resetujemy wszystko po jakiejœ chwili (np. po 2 sekundach)
        StartCoroutine(ResetAfterDelay(2f));
    }

    // Funkcja do resetowania stanu po krótkiej chwili (np. po 2 sekundach)
    IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Resetujemy wszystko na pocz¹tek
        isCubeInSlot = false;
        selectedCube = null;
        feedbackText.text = ""; // Wyczyœæ feedback
        if (npcCube != null)
        {
            Destroy(npcCube); // Zniszcz klocek NPC
        }

        // Losujemy nowy klocek dla NPC na nastêpn¹ turê
        npcChoice = Random.Range(1, 11);
        Debug.Log("NPC wybra³ liczbê: " + npcChoice);
    }
}
