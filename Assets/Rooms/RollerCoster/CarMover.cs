using UnityEngine;

public class CarMover : MonoBehaviour
{
    public Transform[] waypoints; // Punkty trasy
    public float speed = 5f; // Prędkość poruszania się
    private int currentWaypointIndex = 0;
    private bool isMoving = false;

    private void Update()
    {
        if (isMoving && waypoints.Length > 0)
        {
            MoveCar();
        }
    }

    void MoveCar()
    {
        Transform target = waypoints[currentWaypointIndex];

        // PORUSZAMY SIĘ TYLKO WZDŁUŻ TRASY, NIE OBRACAMY SIĘ!
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.position = new Vector3(nextPosition.x, transform.position.y, nextPosition.z); // Blokujemy wysokość Y

        // Jeśli samochód osiągnął punkt, przechodzimy do kolejnego
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                isMoving = false; // Stop po dotarciu do końca toru
            }
        }
    }

    public void StartMoving()
    {
        Debug.Log(" Samochód ruszył po torach!");
        isMoving = true;
    }
}
