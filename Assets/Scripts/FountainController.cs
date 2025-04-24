using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainController : MonoBehaviour

{
    public ParticleSystem waterParticles;   // Przeci�gnij system cz�steczek fontanny
    public Animator waterAnimator;          // Przeci�gnij Animator wody
    public GameObject pedal;                // Obiekt pedla

    private bool isPedalTaken = false;

    void Update()
    {
        // Sprawdzaj, czy pedel zosta� wyj�ty (mo�esz to zrobi� za pomoc� triggera lub interakcji VR)
        if (isPedalTaken == false && CheckPedalRemoved())
        {
            StartWater();
            isPedalTaken = true;
        }
    }

    // Funkcja sprawdzaj�ca, czy pedel zosta� usuni�ty
    bool CheckPedalRemoved()
    {
        // Mo�esz to zrobi�, sprawdzaj�c odleg�o�� pedla od fontanny lub na podstawie interakcji w VR
        return Vector3.Distance(pedal.transform.position, this.transform.position) > 1.0f;
    }

    // Funkcja uruchamiaj�ca wod�
    void StartWater()
    {
        // W��cz system cz�steczek (tryskanie wody)
        waterParticles.Play();

        // Rozpocznij animacj� wzrastania poziomu wody
        waterAnimator.SetTrigger("StartRising");
    }
}
