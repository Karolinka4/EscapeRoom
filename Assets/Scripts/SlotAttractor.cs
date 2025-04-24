using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SlotAttractor : MonoBehaviour
{
    public float attractionSpeed = 3f;
    public float maxAttractDistance = 0.5f; // <- tylko w tym zasiêgu przyci¹ga
    public Transform snapPoint;

    private Transform torchInRange;
    private Rigidbody torchRb;
    private bool isSnapping = false;
    private XRGrabInteractable grabInteractable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torch"))
        {
            float distance = Vector3.Distance(other.transform.position, snapPoint.position);
            if (distance > maxAttractDistance)
            {
                // Zbyt daleko – nie przyci¹gamy
                return;
            }

            torchInRange = other.transform;
            torchRb = other.GetComponent<Rigidbody>();
            grabInteractable = other.GetComponent<XRGrabInteractable>();

            isSnapping = true;

            if (torchRb != null && (grabInteractable == null || !grabInteractable.isSelected))
            {
                torchRb.useGravity = false;
                torchRb.isKinematic = true;
            }
        }
    }

    private void Update()
    {
        if (isSnapping && torchInRange != null)
        {
            torchInRange.position = Vector3.MoveTowards(torchInRange.position, snapPoint.position, attractionSpeed * Time.deltaTime);
            torchInRange.rotation = Quaternion.RotateTowards(torchInRange.rotation, snapPoint.rotation, 360 * Time.deltaTime);

            float distance = Vector3.Distance(torchInRange.position, snapPoint.position);
            if (distance < 0.01f)
            {
                isSnapping = false;

                torchInRange.position = snapPoint.position;
                torchInRange.rotation = snapPoint.rotation;

                if (torchRb != null && (grabInteractable == null || !grabInteractable.isSelected))
                {
                    torchRb.useGravity = false;
                    torchRb.isKinematic = true;
                }
            }
        }
    }
}
