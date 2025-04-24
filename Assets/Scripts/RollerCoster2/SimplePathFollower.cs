
using UnityEngine;

public class SimplePathFollower : MonoBehaviour {
    public Transform[] pathPoints;
    public Transform visualObject;
    public float speed = 5f;
    public bool loop = true;

    public Vector3 rotationOffsetEuler;

    private int currentIndex = 0;

    void Update() {
        if (pathPoints.Length == 0 || visualObject == null) return;

        Transform target = pathPoints[currentIndex];
        Vector3 direction = (target.position - transform.position).normalized;

        visualObject.position = transform.position;

        // Obrót tylko wizualnego obiektu
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            lookRotation *= Quaternion.Euler(rotationOffsetEuler);
            visualObject.rotation = Quaternion.Slerp(visualObject.rotation, lookRotation, Time.deltaTime * 5f);
        }

        // Ruch obiektu bazowego
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentIndex++;
            if (currentIndex >= pathPoints.Length)
            {
                if (loop) currentIndex = 0;
                else enabled = false;
            }
        }
    }
}
