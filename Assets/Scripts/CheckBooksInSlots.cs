using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookSlotManager : MonoBehaviour
{
    public BookSlot[] slots;
    public Animator doorAnimator;
    private bool animationPlayed = false;

    private void Update()
    {
        bool allCorrect = true;

        foreach (var slot in slots)
        {
            if (!slot.isCorrect)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect && !animationPlayed)
        {
            doorAnimator.SetTrigger("Open");
            animationPlayed = true;
        }
    }
}
