using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strzaly_sciana : MonoBehaviour
{
    public Animator arrowAnimator;  // Referencja do animatora strza³y

    // Funkcja wywo³ywana, kiedy coœ wejdzie w trigger
    private void OnTriggerEnter(Collider other)
    {
       
        // Sprawdzanie, czy obiekt ma tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz wszed³ w trigger!");
            // Ustawienie bool 'start' w Animatorze na true, co uruchomi animacjê
            arrowAnimator.SetBool("start", true);
        } 
    }


}
