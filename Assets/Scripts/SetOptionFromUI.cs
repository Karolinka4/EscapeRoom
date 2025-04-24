using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetOptionFromUI : MonoBehaviour
{
    public SetTurnTypeFromPlayerPref turnTypeFromPlayerPref;  // Pozostawiamy tylko t� zmienn�, je�li jest u�ywana

    private void Start()
    {
        // Sprawd�, czy turnTypeFromPlayerPref zosta�o przypisane w Inspectorze
        if (turnTypeFromPlayerPref != null)
        {
            if (PlayerPrefs.HasKey("turn"))
            {
                turnTypeFromPlayerPref.ApplyPlayerPref();
            }
        }
        else
        {
            Debug.LogError("TurnTypeFromPlayerPref is not assigned in the Inspector!");
        }
    }

    public void SetTurnPlayerPref(int value)
    {
        PlayerPrefs.SetInt("turn", value);
        if (turnTypeFromPlayerPref != null)
        {
            turnTypeFromPlayerPref.ApplyPlayerPref();
        }
        else
        {
            Debug.LogError("TurnTypeFromPlayerPref is not assigned in the Inspector!");
        }
    }
}
