using UnityEngine;

public class FireStarter : MonoBehaviour
{
    public ParticleSystem[] fireEffects; // Mo¿esz dodaæ kilka efektów
    private bool hasStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasStarted && other.CompareTag("Player")) // lub "XR Rig", zale¿y od Twojego setupu
        {
            foreach (var effect in fireEffects)
            {
                effect.Play();
            }
            hasStarted = true;
        }
    }
}
