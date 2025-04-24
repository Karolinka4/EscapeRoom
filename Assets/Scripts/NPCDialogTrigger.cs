using System.Collections;
using UnityEngine;
using TMPro;

public class NPCDialogTrigger : MonoBehaviour
{
    public NPCDialog npcDialog; // Przypisz skrypt monologu NPC
    public string[] npcLines; // Tekst, który ma mówiæ NPC

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Gracz wchodzi w trigger
        {
            npcDialog.StartDialogue(npcLines);
        }
    }
}
