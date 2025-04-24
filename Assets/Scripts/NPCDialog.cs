using System.Collections;
using UnityEngine;
using TMPro;

public class NPCDialog : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public GameObject dialogPanel;
    public float textSpeed = 0.05f;

    private string[] dialogLines;
    private int currentLine;
    private bool isTalking = false;

    void Start()
    {
        dialogPanel.SetActive(false);
    }

    public void StartDialogue(string[] lines)
    {
        if (!isTalking)
        {
            dialogLines = lines;
            currentLine = 0;
            dialogPanel.SetActive(true);
            StartCoroutine(TypeLine());
        }
    }

    IEnumerator TypeLine()
    {
        isTalking = true;
        dialogText.text = "";

        foreach (char letter in dialogLines[currentLine].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(2f); // Pauza przed nastêpn¹ lini¹
        NextLine();
    }

    void NextLine()
    {
        if (currentLine < dialogLines.Length - 1)
        {
            currentLine++;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialogPanel.SetActive(false);
        isTalking = false;
    }
}
