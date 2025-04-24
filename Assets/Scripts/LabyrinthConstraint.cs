using UnityEngine;

public class LabyrinthConstraint : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Zapewnia, �e zw�j pozostaje wewn�trz labiryntu
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 0.2f))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                // Odepchnij zw�j, je�li dotyka �ciany
                Vector3 pushBack = hit.normal * 0.1f;
                rb.position += pushBack;
                rb.velocity = Vector3.zero;
            }
        }
    }
}
