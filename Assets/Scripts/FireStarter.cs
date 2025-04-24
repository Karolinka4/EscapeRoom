using UnityEngine;

public class FireStarter : MonoBehaviour
{
    public ParticleSystem[] fireEffects; // Mo�esz doda� kilka efekt�w
    private bool hasStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasStarted && other.CompareTag("Player")) // lub "XR Rig", zale�y od Twojego setupu
        {
            foreach (var effect in fireEffects)
            {
                effect.Play();
            }
            hasStarted = true;
        }
    }
}
