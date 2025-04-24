using UnityEngine;

public class SlotChecker : MonoBehaviour
{
    public int correctValue; // Poprawna cyfra w tym slocie
    private CubeNumber placedCube; // Cube, który zosta³ tu umieszczony

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
