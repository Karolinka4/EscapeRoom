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
        Debug.Log("Klucz zosta³ podniesiony!");
    }

    void OnGrabNakretka(SelectEnterEventArgs args)
    {
        Debug.Log("Nakrêtka zosta³a podniesiona!");
        if (fixedJoint != null)
        {
            Debug.Log("FixedJoint zostanie zniszczony.");
            Destroy(fixedJoint);
            fixedJoint = null; // Upewnij siê, ¿e fixedJoint jest ustawiony na null po zniszczeniu
            Physics.IgnoreCollision(klucz.GetComponent<Collider>(), nakretka.GetComponent<Collider>(), true);
            Rigidbody rbNakretka = nakretka.GetComponent<Rigidbody>();
            rbNakretka.AddForce(Vector3.up * 5, ForceMode.Impulse); // Dostosuj si³ê wed³ug potrzeb
        }
    }

    void Update()
    {
        // Logika odkrêcania nakrêtki
        if (nakretka.isSelected)
        {
            Debug.Log("Nakrêtka jest obracana.");
            nakretka.transform.Rotate(Vector3.up, 20 * Time.deltaTime);
        }
    }
}