using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public CarMover carMover;
    private Transform playerTransform;
    private bool isOnCar = false;
    private Vector3 lastCarPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            lastCarPosition = carMover.transform.position;
            isOnCar = true;

            Debug.Log(" Gracz wszedł na samochód!");
            carMover.StartMoving(); // Samochód startuje
        }
    }

    private void LateUpdate()
    {
        if (isOnCar && playerTransform != null)
        {
            // Przesuwamy gracza o ten sam ruch, który wykonał samochód
            Vector3 carMovement = carMover.transform.position - lastCarPosition;
            playerTransform.position += carMovement;

            // Aktualizujemy ostatnią pozycję samochodu
            lastCarPosition = carMover.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnCar = false;
            Debug.Log("Gracz wyszedł z samochodu.");
        }
    }
}
