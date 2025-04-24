using UnityEngine;

public class Dice : MonoBehaviour
{
    public int Result { get; private set; }

    private bool hasStopped = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!hasStopped && rb.IsSleeping()) // Sprawdza, czy koœæ siê zatrzyma³a
        {
            hasStopped = true;
            DetermineResult();
        }
    }

    void DetermineResult()
    {
        // Sprawdza, która œciana jest najwy¿ej
        Transform highestFace = null;
        float maxDot = -1;

        foreach (Transform child in transform)
        {
            float dot = Vector3.Dot(child.up, Vector3.up);
            if (dot > maxDot)
            {
                maxDot = dot;
                highestFace = child;
            }
        }

        if (highestFace != null)
        {
            // Spróbuj przekonwertowaæ nazwê na liczbê
            if (int.TryParse(highestFace.name, out int result))
            {
                Result = result;
            }
            else
            {
                Debug.LogError("Nie uda³o siê przekonwertowaæ nazwy œciany na liczbê: " + highestFace.name);
                Result = 0;  // Ustawienie domyœlnego wyniku w przypadku b³êdu
            }
        }
    }
}
