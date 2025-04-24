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
        if (!hasStopped && rb.IsSleeping()) // Sprawdza, czy ko�� si� zatrzyma�a
        {
            hasStopped = true;
            DetermineResult();
        }
    }

    void DetermineResult()
    {
        // Sprawdza, kt�ra �ciana jest najwy�ej
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
            // Spr�buj przekonwertowa� nazw� na liczb�
            if (int.TryParse(highestFace.name, out int result))
            {
                Result = result;
            }
            else
            {
                Debug.LogError("Nie uda�o si� przekonwertowa� nazwy �ciany na liczb�: " + highestFace.name);
                Result = 0;  // Ustawienie domy�lnego wyniku w przypadku b��du
            }
        }
    }
}
