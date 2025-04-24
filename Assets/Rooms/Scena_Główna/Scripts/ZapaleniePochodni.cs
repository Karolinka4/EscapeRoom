using UnityEngine;

public class ZapaleniePochodni : MonoBehaviour
{
    public GameObject torchFire;  // Referencja do obiektu ognia na pochodni
    public Transform glassesFocusPoint;  // Punkt, w którym ogniskuj¹ siê promienie okularów
    public Transform torchHead;  // G³owica pochodni
    public float ignitionDistance = 0.1f;  // Dystans, przy którym pochodnia zapala siê
    public Light sunLight;  // Referencja do s³oñca w scenie
    public float minimumLightIntensity = 0.5f;  // Minimalna intensywnoœæ œwiat³a s³onecznego do zapalenia

    private bool isTorchLit = false;  // Czy pochodnia jest ju¿ zapalona?

    void Start()
    {
        // Na pocz¹tku ogieñ na pochodni powinien byæ wy³¹czony
        torchFire.SetActive(false);
    }

    void Update()
    {
        // SprawdŸ odleg³oœæ miêdzy punktem ogniskowania okularów a g³owic¹ pochodni
        float distance = Vector3.Distance(glassesFocusPoint.position, torchHead.position);

        // SprawdŸ czy œwiat³o s³oneczne jest wystarczaj¹co mocne
        if (distance <= ignitionDistance && sunLight.intensity >= minimumLightIntensity && !isTorchLit)
        {
            IgniteTorch();
        }
    }

    void IgniteTorch()
    {
        isTorchLit = true;
        torchFire.SetActive(true);  // W³¹cz obiekt ognia
        Debug.Log("Pochodnia zapalona!");
    }
}