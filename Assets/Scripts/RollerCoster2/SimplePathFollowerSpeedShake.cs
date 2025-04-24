using UnityEngine;
using UnityEngine.SceneManagement;
public class SimplePathFollowerSpeedShake : MonoBehaviour
{
    [Header("Trasa")]
    public Transform pathParent;         // <- obiekt typu "PathPoints"
    public Transform[] pathPoints;
    public SceneFader sceneFader;

    [Header("Podstawowe ustawienia")]
    public Transform visualObject;
    public float baseSpeed = 3.5f;
    public float acceleration = 1.5f;
    [Header("Fade i scena")]
    public string sceneName = "ScenaDocelowa"; // <- ustaw w Inspectorze nazw� sceny
    public bool loop = true;

    public Vector3 rotationOffsetEuler;

    [Header("Shake podczas jazdy")]
    public Transform shakeObject;
    public float shakeIntensity = 0.025f;
    public float shakeFrequency = 18f;

    private float currentSpeed = 0f;
    private int currentIndex = 0;
    private Vector3 shakeOffset;

    void Start()
    {
        if (pathParent != null && pathPoints.Length == 0)
        {
            pathPoints = new Transform[pathParent.childCount];
            for (int i = 0; i < pathParent.childCount; i++)
            {
                pathPoints[i] = pathParent.GetChild(i);
            }
        }
    }

    void Update()
    {
        if (pathPoints.Length < 2 || visualObject == null) return;

        Transform target = pathPoints[currentIndex];
        Vector3 direction = (target.position - transform.position).normalized;

        float targetSpeed = baseSpeed;

        if (currentIndex > 0 && currentIndex < pathPoints.Length - 1)
        {
            Vector3 dirA = (pathPoints[currentIndex].position - pathPoints[currentIndex - 1].position).normalized;
            Vector3 dirB = (pathPoints[currentIndex + 1].position - pathPoints[currentIndex].position).normalized;
            float turnAngle = Vector3.Angle(dirA, dirB);

            if (turnAngle > 45f) targetSpeed -= 2f;     // Zakr�t
            if (turnAngle > 90f) targetSpeed -= 3.5f;   // Ostry zakr�t
        }

        //  Dodatkowe spowolnienie przy je�dzie pod g�rk�
        float heightDelta = target.position.y - transform.position.y;
        targetSpeed -= heightDelta * 2f; // np. 1 jednostka w g�r� = -2 pr�dko�ci

        //  Wolny start
        if (Time.timeSinceLevelLoad < 3f)
            targetSpeed *= 0.5f;

        //  Bezpiecze�stwo: nie mniej ni� 0
        targetSpeed = Mathf.Max(1f, targetSpeed);

        // Przyspieszenie/hamowanie
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        // Ruch
        transform.position += direction * currentSpeed * Time.deltaTime;

        // Obr�t
        visualObject.position = transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            lookRotation *= Quaternion.Euler(rotationOffsetEuler);
            visualObject.rotation = Quaternion.Slerp(visualObject.rotation, lookRotation, Time.deltaTime * 5f);
        }

        // Shake efekt
        if (shakeObject != null)
        {
            float speedFactor = Mathf.Clamp01(currentSpeed / baseSpeed);
            float shakeX = Mathf.PerlinNoise(Time.time * shakeFrequency, 0f) - 0.5f;
            float shakeY = Mathf.PerlinNoise(0f, Time.time * shakeFrequency) - 0.5f;
            float shakeZ = Mathf.PerlinNoise(Time.time * shakeFrequency, Time.time * shakeFrequency) - 0.5f;

            shakeOffset = new Vector3(shakeX, shakeY, shakeZ) * shakeIntensity * speedFactor;
            shakeObject.localPosition = shakeOffset;
        }

        // Zmiana punktu
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            currentIndex++;
            if (currentIndex >= pathPoints.Length)
            {
                currentSpeed = 0f; // zatrzymaj ruch
                enabled = false; // wy��cz Update()

                // (opcjonalnie) mo�esz doda� efekt ko�ca trasy lub op�nienie
                Invoke("LoadNextScene", 2f); // przej�cie po 2 sekundach
            }
        }

    }
    void LoadNextScene()
    {
        if (sceneFader != null)
            sceneFader.FadeToScene(sceneName);
        else
            Debug.LogWarning("Brakuje przypisanego SceneFader!");
    }
}
