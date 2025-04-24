using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Zwoj : MonoBehaviour
{
    public XRGrabInteractable klucz;
    public XRGrabInteractable nakretka;
    private FixedJoint fixedJoint;

    void Start()
    {
        fixedJoint = klucz.gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = nakretka.GetComponent<Rigidbody>();

        klucz.selectEntered.AddListener(OnGrabKlucz);
        nakretka.selectEntered.AddListener(OnGrabNakretka);
    }

    void OnGrabKlucz(SelectEnterEventArgs args)
    {
        Debug.Log("Klucz zosta� podniesiony!");
    }

    void OnGrabNakretka(SelectEnterEventArgs args)
    {
        Debug.Log("Nakr�tka zosta�a podniesiona!");
        if (fixedJoint != null)
        {
            Debug.Log("FixedJoint zostanie zniszczony.");
            Destroy(fixedJoint);
            fixedJoint = null; // Upewnij si�, �e fixedJoint jest ustawiony na null po zniszczeniu
            Physics.IgnoreCollision(klucz.GetComponent<Collider>(), nakretka.GetComponent<Collider>(), true);
            Rigidbody rbNakretka = nakretka.GetComponent<Rigidbody>();
            rbNakretka.AddForce(Vector3.up * 5, ForceMode.Impulse); // Dostosuj si�� wed�ug potrzeb
        }
    }

    void Update()
    {
        // Logika odkr�cania nakr�tki
        if (nakretka.isSelected)
        {
            Debug.Log("Nakr�tka jest obracana.");
            nakretka.transform.Rotate(Vector3.up, 20 * Time.deltaTime);
        }
    }
}