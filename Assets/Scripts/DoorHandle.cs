using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandle : MonoBehaviour
{
    public Transform drzwi; // Obiekt drzwi
    public float openAngle = 90f; // Maksymalny k¹t otwarcia drzwi
    public float speed = 3f; // Szybkoœæ otwierania drzwi
    public float pullThreshold = 0.1f; // Minimalna odleg³oœæ do otwarcia drzwi

    private Vector3 startPosition;
    private bool drzwiOtwarte = false;

    void Start()
    {
        startPosition = transform.position; // Zapisz pocz¹tkow¹ pozycjê klamki
    }

    void Update()
    {
        float distance = Vector3.Distance(startPosition, transform.position);

        if (!drzwiOtwarte && distance > pullThreshold)
        {
            StartCoroutine(OtworzDrzwi());
            drzwiOtwarte = true;
        }
    }

    private System.Collections.IEnumerator OtworzDrzwi()
    {
        Quaternion startRotation = drzwi.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, openAngle, 0);

        float time = 0;
        while (time < 1)
        {
            drzwi.rotation = Quaternion.Slerp(startRotation, targetRotation, time);
            time += Time.deltaTime * speed;
            yield return null;
        }
    }
}
