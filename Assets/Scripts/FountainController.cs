using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainController : MonoBehaviour

{
    public ParticleSystem waterParticles;   // Przeci¹gnij system cz¹steczek fontanny
    public Animator waterAnimator;          // Przeci¹gnij Animator wody
    public GameObject pedal;                // Obiekt pedla

    private bool isPedalTaken = false;

    void Update()
    {
        // Sprawdzaj, czy pedel zosta³ wyjêty (mo¿esz to zrobiæ za pomoc¹ triggera lub interakcji VR)
        if (isPedalTaken == false && CheckPedalRemoved())
        {
            StartWater();
            isPedalTaken = true;
        }
    }

    // Funkcja sprawdzaj¹ca, czy pedel zosta³ usuniêty
    bool CheckPedalRemoved()
    {
        // Mo¿esz to zrobiæ, sprawdzaj¹c odleg³oœæ pedla od fontanny lub na podstawie interakcji w VR
        return Vector3.Distance(pedal.transform.position, this.transform.position) > 1.0f;
    }

    // Funkcja uruchamiaj¹ca wodê
    void StartWater()
    {
        // W³¹cz system cz¹steczek (tryskanie wody)
        waterParticles.Play();

        // Rozpocznij animacjê wzrastania poziomu wody
        waterAnimator.SetTrigger("StartRising");
    }
}
