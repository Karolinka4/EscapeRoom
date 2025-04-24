using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeSlotGame : MonoBehaviour
{
    public Transform slotTransformGracz;  // Slot gracza, do kt�rego gracz wk�ada klocek
    public Transform slotTransformNpc;  // Slot NPC, do kt�rego pojawi si� klocek NPC
    public GameObject npcCubePrefab;  // Prefab klocka NPC, kt�ry pojawi si� w slocie NPC
    public TextMeshProUGUI feedbackText;  // Tekst feedbacku dla gracza (np. "Brawo!", "Spr�buj ponownie")

    public GameObject[] playerCubes;  // Tablica prefab�w klock�w gracza (od 1 do 10)

    private int npcChoice = -1;     // Losowy wyb�r NPC
    private GameObject selectedCube = null; // Klocek wybrany przez gracza
    private GameObject npcCube = null; // Klocek NPC
    private bool isCubeInSlot = false; // Flaga, czy klocek jest w slocie

    void Start()
    {
        npcChoice = Random.Range(1, 11);  // Losowanie liczby przez NPC (od 1 do 10)
        Debug.Log("NPC wybra� liczb�: " + npcChoice);  // Mo�emy zobaczy�, jak� liczb� wylosowa� NPC
        feedbackText.text = ""; // Na pocz�tku brak feedbacku
    }

    // Funkcja wywo�ywana po tym, jak gracz wybierze klocek i chce go umie�ci�
    public void OnCubeSelected(GameObject cube)
    {
        // Gracz wybra� klocek, wi�c go przypisujemy
        selectedCube = cube;
        // Przemieszczamy klocek do slotu gracza
        MoveCubeToSlot();
    }

    // Funkcja przyci�gaj�ca klocek do slotu gracza
    void MoveCubeToSlot()
    {
        if (selectedCube != null && !isCubeInSlot)
        {
            // Przyci�ganie klocka do slotu gracza przy pomocy interpolacji (Lerp)
            selectedCube.transform.position = Vector3.Lerp(selectedCube.transform.position, slotTransformGracz.position, Time.deltaTime * 5f);

            // Je�li klocek jest wystarczaj�co blisko slotu, uznajemy, �e trafi� do slotu
            if (Vector3.Distance(selectedCube.transform.position, slotTransformGracz.position) < 0.1f)
            {
                selectedCube.transform.position = slotTransformGracz.position; // Dok�adne ustawienie klocka w slot
                isCubeInSlot = true;  // Ustawiamy flag�, �e klocek jest w slocie

                // Teraz po umieszczeniu klocka przez gracza, wy�wietlamy klocek NPC w jego slocie
                ShowNpcCube();
                // Sprawdzamy, czy gracz zgad� liczb�
                CheckSlot();
            }
        }
    }

    // Funkcja, kt�ra pokazuje klocek NPC w slocie NPC
    void ShowNpcCube()
    {
        // Tworzymy prefab klocka NPC (je�li jeszcze go nie mamy)
        if (npcCube == null)
        {
            npcCube = Instantiate(npcCubePrefab, slotTransformNpc.position, Quaternion.identity); // Tworzymy klocek NPC w slocie NPC
            TMP_Text npcText = npcCube.GetComponentInChildren<TMP_Text>(); // U�ywamy TMP_Text zamiast TextMesh
            npcText.text = npcChoice.ToString();  // Przypisujemy tekst (cyfr�) do klocka NPC
        }
    }

    // Funkcja do sprawdzania, czy gracz zgad�
    void CheckSlot()
    {
        // Pobieramy cyfr� z klocka wybranego przez gracza
        int playerChoice = int.Parse(selectedCube.GetComponentInChildren<TMP_Text>().text);

        // Sprawdzamy, czy wyb�r gracza pasuje do wyboru NPC
        if (playerChoice == npcChoice)
        {
            feedbackText.text = "Brawo! Zgad�e�!"; // Gracz zgad�
        }
        else
        {
            feedbackText.text = "Niestety, spr�buj ponownie."; // Gracz nie zgad�
        }

        // Resetujemy wszystko po jakiej� chwili (np. po 2 sekundach)
        StartCoroutine(ResetAfterDelay(2f));
    }

    // Funkcja do resetowania stanu po kr�tkiej chwili (np. po 2 sekundach)
    IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Resetujemy wszystko na pocz�tek
        isCubeInSlot = false;
        selectedCube = null;
        feedbackText.text = ""; // Wyczy�� feedback
        if (npcCube != null)
        {
            Destroy(npcCube); // Zniszcz klocek NPC
        }

        // Losujemy nowy klocek dla NPC na nast�pn� tur�
        npcChoice = Random.Range(1, 11);
        Debug.Log("NPC wybra� liczb�: " + npcChoice);
    }
}
