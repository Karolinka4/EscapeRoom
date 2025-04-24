using UnityEngine;
using System.Collections;

public class CoasterMovement : MonoBehaviour
{
    public Transform[] trackPoints; // Punkty toru
    public float speed = 5f;
    public float startDelay = 3f; // Opóźnienie startu w sekundach
    private int currentPoint = 0;
    private bool isMoving = false;

    void Start()
    {
        StartCoroutine(StartAfterDelay());
    }

    IEnumerator StartAfterDelay()
    {
        yield return new WaitForSeconds(startDelay); // Czekaj kilka sekund
        isMoving = true;
    }
    //transform.lookat
    void Update()
    {
        if (isMoving && currentPoint < trackPoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, trackPoints[currentPoint].position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, trackPoints[currentPoint].position) < 0.1f)
                currentPoint++;
        }
    }
}
