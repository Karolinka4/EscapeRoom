using UnityEngine;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    public TMP_Text displayText; // Wyœwietlanie kodu
    private string enteredCode = ""; // Wpisany kod
    private string correctCode = "3579"; // Poprawny kod

    public Color correctColor = Color.green;
    public Color errorColor = Color.red;
    public Animator spikesAnimator; // przypnij Kolce tutaj w Inspectorze
    public void ButtonPressed(string value)
    {
        Debug.Log("Klikniêto: " + value);

        if (enteredCode.Length < 4)
        {
            enteredCode += value;
            displayText.text = enteredCode;
            displayText.color = Color.white;
        }

        if (enteredCode.Length == 4)
        {
            CheckCode();
        }
    }

    private void CheckCode()
    {
        Debug.Log("Sprawdzam kod: " + enteredCode);
        if (enteredCode == correctCode)
        {
            Debug.Log("Kod poprawny!");
            displayText.text = "Correct";
            displayText.color = correctColor;

            if (spikesAnimator != null)
            {
                Debug.Log("Wysy³am trigger CloseKolce");
                spikesAnimator.SetTrigger("CloseKolce");
            }
        }
        else
        {
            Debug.Log("Kod b³êdny!");
            displayText.text = "Error";
            displayText.color = errorColor;
        }

        Invoke("ResetCode", 1.5f);
    }

    private void ResetCode()
    {
        enteredCode = "";
        displayText.text = "";
        displayText.color = Color.white;
    }
}
