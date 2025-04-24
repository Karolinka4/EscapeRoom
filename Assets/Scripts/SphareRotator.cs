using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class SphereRotator : MonoBehaviour
{
    private bool isRotating = false;
    public float rotationSpeed = 5f;  // Mo¿esz dostosowaæ prêdkoœæ obrotu

    public void RotateUp()
    {
        if (!isRotating)
            StartCoroutine(RotateSmoothly(Vector3.right * 45));  // Zmieniono z 90 na 45
    }

    public void RotateDown()
    {
        if (!isRotating)
            StartCoroutine(RotateSmoothly(Vector3.left * 45));  // Zmieniono z 90 na 45
    }

    public void RotateLeft()
    {
        if (!isRotating)
            StartCoroutine(RotateSmoothly(Vector3.forward * 45));  // Zmieniono z 90 na 45
    }

    public void RotateRight()
    {
        if (!isRotating)
            StartCoroutine(RotateSmoothly(Vector3.back * 45));  // Zmieniono z 90 na 45
    }

    private IEnumerator RotateSmoothly(Vector3 rotationDirection)
    {
        isRotating = true;

        // Docelowa rotacja (o 45 stopni w danym kierunku)
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(rotationDirection);

        float timeElapsed = 0f;

        // Obracanie obiektu p³ynnie
        while (timeElapsed < 1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, timeElapsed * rotationSpeed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Po zakoñczeniu rotacji ustawiamy koñcow¹ rotacjê
        transform.rotation = targetRotation;

        isRotating = false;
    }
}
