using UnityEngine;

public class ZapaleniePochodni : MonoBehaviour
{
    public GameObject torchFire;  // Referencja do obiektu ognia na pochodni
    public Transform glassesFocusPoint;  // Punkt, w kt�rym ogniskuj� si� promienie okular�w
    public Transform torchHead;  // G�owica pochodni
    public float ignitionDistance = 0.1f;  // Dystans, przy kt�rym pochodnia zapala si�
    public Light sunLight;  // Referencja do s�o�ca w scenie
    public float minimumLightIntensity = 0.5f;  // Minimalna intensywno�� �wiat�a s�onecznego do zapalenia

    private bool isTorchLit = false;  // Czy pochodnia jest ju� zapalona?

    void Start()
    {
        // Na pocz�tku ogie� na pochodni powinien by� wy��czony
        torchFire.SetActive(false);
    }

    void Update()
    {
        // Sprawd� odleg�o�� mi�dzy punktem ogniskowania okular�w a g�owic� pochodni
        float distance = Vector3.Distance(glassesFocusPoint.position, torchHead.position);

        // Sprawd� czy �wiat�o s�oneczne jest wystarczaj�co mocne
        if (distance <= ignitionDistance && sunLight.intensity >= minimumLightIntensity && !isTorchLit)
        {
            IgniteTorch();
        }
    }

    void IgniteTorch()
    {
        isTorchLit = true;
        torchFire.SetActive(true);  // W��cz obiekt ognia
        Debug.Log("Pochodnia zapalona!");
    }
}