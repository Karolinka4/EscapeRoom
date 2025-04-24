using UnityEngine;

public class SlotChecker : MonoBehaviour
{
    public int correctValue; // Poprawna cyfra w tym slocie
    private CubeNumber placedCube; // Cube, kt�ry zosta� tu umieszczony

    public bool IsCorrect()
    {
        return placedCube != null && placedCube.value == correctValue;
    }

    public void SetPlacedCube(CubeNumber cube)
    {
        placedCube = cube;
    }

    public void ClearSlot()
    {
        placedCube = null;
    }
}
