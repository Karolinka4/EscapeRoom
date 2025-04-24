
using UnityEngine;

public class SimplePathFollowerSpeed : MonoBehaviour {
    public Transform[] pathPoints;
    public Transform visualObject;
    public float baseSpeed = 5f;
    public float acceleration = 2f;

    public bool loop = true;

    public Vector3 rotationOffsetEuler;

    private float currentSpeed = 0f;
    private int currentIndex = 0;

    void Update() {
        if (pathPoints.Length < 2 || visualObject == null) return;
        Debug.Log($"Speed: {currentSpeed} | Index: {currentIndex} | Pos: {transform.position}");
        Transform target = pathPoints[currentIndex];
        Vector3 direction = (target.position - transform.position).normalized;

        float targetSpeed = baseSpeed;

        if (currentIndex > 0 && currentIndex < pathPoints.Length - 1)
        {
            Vector3 dirA = (pathPoints[currentIndex].position - pathPoints[currentIndex - 1].position).normalized;
            Vector3 dirB = (pathPoints[currentIndex + 1].position - pathPoints[currentIndex].position).normalized;
            float turnAngle = Vector3.Angle(dirA, dirB);

            if (turnAngle > 45f) targetSpeed -= 2f;     // Zakrêt
            if (turnAngle > 90f) targetSpeed -= 3.5f;   // Ostry zakrêt
        }

        //  Dodatkowe spowolnienie przy jeŸdzie pod górkê
        float heightDelta = target.position.y - transform.position.y;
        targetSpeed -= heightDelta * 2f; // np. 1 jednostka w górê = -2 prêdkoœci

        //  Wolny start
        if (Time.timeSinceLevelLoad < 3f)
            targetSpeed *= 0.5f;

        //  Bezpieczeñstwo: nie mniej ni¿ 0
        targetSpeed = Mathf.Max(1f, targetSpeed);

        // Przyspieszenie/hamowanie
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        // Ruch
        transform.position += direction * currentSpeed * Time.deltaTime;

        // Obrót
        visualObject.position = transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            lookRotation *= Quaternion.Euler(rotationOffsetEuler);
            visualObject.rotation = Quaternion.Slerp(visualObject.rotation, lookRotation, Time.deltaTime * 5f);
        }

        // Zmiana punktu
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
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
