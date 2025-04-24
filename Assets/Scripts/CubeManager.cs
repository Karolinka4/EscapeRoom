using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public Animator animator;
    public CubeSlotChecker slot1;
    public CubeSlotChecker slot2;

    public void CheckWin()
    {
        if (slot1.isFilled && slot2.isFilled)
        {
            animator.SetTrigger("OpenCegly");
        }
    }
}