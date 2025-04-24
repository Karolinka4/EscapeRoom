using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookSlot : MonoBehaviour
{
    public GameObject book;  // Ksi��ka przypisana do slotu
    public bool isCorrect = false;

    public float snapDistance = 0.2f;  // Dystans, w kt�rym ksi��ka "przyci�ga" si� do slotu
    public float snapSpeed = 5f;       // Pr�dko�� przyci�gania ksi��ki do slotu
    public float rotationSpeed = 10f;  // Pr�dko�� obracania ksi��ki

    private bool isSnapping = false;
    private BookInteract bookInteract; // Odwo�anie do istniej�cego skryptu, kt�ry obs�uguje interakcj� z ksi��k�

    private void Start()
    {
        if (book != null)
        {
            bookInteract = book.GetComponent<BookInteract>(); // Zak�adamy, �e masz skrypt BookInteract, kt�ry trzyma referencj� do XRGrabInteractable
        }
    }

    private void Update()
    {
        if (book == null || bookInteract == null) return;

        // Obliczamy dystans mi�dzy ksi��k� a slotem
        float distance = Vector3.Distance(book.transform.position, transform.position);

        // Sprawdzamy, czy ksi��ka zosta�a puszczona (czy nie jest trzymana) i jest w pobli�u slotu
        if (!bookInteract.isHeld && distance < snapDistance)
        {
            isSnapping = true;
        }

        // Je�li ksi��ka jest blisko, zaczynamy j� przyci�ga� do slotu
        if (isSnapping)
        {
            // Przyci�ganie pozycji ksi��ki
            book.transform.position = Vector3.Lerp(
                book.transform.position,
                transform.position, // Pozycja slotu
                Time.deltaTime * snapSpeed
            );

            // Przyci�ganie rotacji ksi��ki
            book.transform.rotation = Quaternion.RotateTowards(
                book.transform.rotation,
                transform.rotation, // Rotacja slotu
                rotationSpeed * Time.deltaTime // Rotacja w czasie, aby nie by�a zbyt szybka
            );

            // Je�li ksi��ka jest wystarczaj�co blisko slotu, ustawiamy j� dok�adnie w slotcie
            if (distance < 0.05f)
            {
                book.transform.position = transform.position; // Ustawienie pozycji
                book.transform.rotation = transform.rotation; // Ustawienie rotacji
                isCorrect = true;
                isSnapping = false;

                // Opcjonalnie: Zablokowanie Rigidbody, je�li ksi��ka jest poprawnie umieszczona w slocie
                Rigidbody rb = book.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true; // Blokujemy fizyk� ksi��ki, je�li jest ju� w slocie
                }

                // Opcjonalnie: Wy��czenie interakcji XRGrabInteractable, je�li ksi��ka jest w slocie
                var grab = book.GetComponent<XRGrabInteractable>();
                if (grab != null)
                {
                    grab.enabled = false; // Wy��czenie interakcji, gdy ksi��ka jest na swoim miejscu
                }
            }
            else
            {
                isCorrect = false;
            }
        }
        else
        {
            isCorrect = false;
        }
    }
}
