using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookSlot : MonoBehaviour
{
    public GameObject book;  // Ksi¹¿ka przypisana do slotu
    public bool isCorrect = false;

    public float snapDistance = 0.2f;  // Dystans, w którym ksi¹¿ka "przyci¹ga" siê do slotu
    public float snapSpeed = 5f;       // Prêdkoœæ przyci¹gania ksi¹¿ki do slotu
    public float rotationSpeed = 10f;  // Prêdkoœæ obracania ksi¹¿ki

    private bool isSnapping = false;
    private BookInteract bookInteract; // Odwo³anie do istniej¹cego skryptu, który obs³uguje interakcjê z ksi¹¿k¹

    private void Start()
    {
        if (book != null)
        {
            bookInteract = book.GetComponent<BookInteract>(); // Zak³adamy, ¿e masz skrypt BookInteract, który trzyma referencjê do XRGrabInteractable
        }
    }

    private void Update()
    {
        if (book == null || bookInteract == null) return;

        // Obliczamy dystans miêdzy ksi¹¿k¹ a slotem
        float distance = Vector3.Distance(book.transform.position, transform.position);

        // Sprawdzamy, czy ksi¹¿ka zosta³a puszczona (czy nie jest trzymana) i jest w pobli¿u slotu
        if (!bookInteract.isHeld && distance < snapDistance)
        {
            isSnapping = true;
        }

        // Jeœli ksi¹¿ka jest blisko, zaczynamy j¹ przyci¹gaæ do slotu
        if (isSnapping)
        {
            // Przyci¹ganie pozycji ksi¹¿ki
            book.transform.position = Vector3.Lerp(
                book.transform.position,
                transform.position, // Pozycja slotu
                Time.deltaTime * snapSpeed
            );

            // Przyci¹ganie rotacji ksi¹¿ki
            book.transform.rotation = Quaternion.RotateTowards(
                book.transform.rotation,
                transform.rotation, // Rotacja slotu
                rotationSpeed * Time.deltaTime // Rotacja w czasie, aby nie by³a zbyt szybka
            );

            // Jeœli ksi¹¿ka jest wystarczaj¹co blisko slotu, ustawiamy j¹ dok³adnie w slotcie
            if (distance < 0.05f)
            {
                book.transform.position = transform.position; // Ustawienie pozycji
                book.transform.rotation = transform.rotation; // Ustawienie rotacji
                isCorrect = true;
                isSnapping = false;

                // Opcjonalnie: Zablokowanie Rigidbody, jeœli ksi¹¿ka jest poprawnie umieszczona w slocie
                Rigidbody rb = book.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true; // Blokujemy fizykê ksi¹¿ki, jeœli jest ju¿ w slocie
                }

                // Opcjonalnie: Wy³¹czenie interakcji XRGrabInteractable, jeœli ksi¹¿ka jest w slocie
                var grab = book.GetComponent<XRGrabInteractable>();
                if (grab != null)
                {
                    grab.enabled = false; // Wy³¹czenie interakcji, gdy ksi¹¿ka jest na swoim miejscu
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
