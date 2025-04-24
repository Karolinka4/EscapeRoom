using UnityEngine;

public class CubeSlotChecker : MonoBehaviour
{
    public GameObject correctCube;
    public CubeManager manager;

    public bool isFilled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isFilled && other.gameObject == correctCube)
        {
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
            other.GetComponent<Rigidbody>().isKinematic = true;

            isFilled = true;
            manager.CheckWin();
        }
    }
}
