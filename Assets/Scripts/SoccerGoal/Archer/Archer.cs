
public class Archer 
{
    #region Properties and fields

    public bool IsArcherEnabled = true;
    public float TargetSpeed = 5f;
    public float ArcherkeeperZDistance = 6f;
    public bool MovementStartsRight = false;
    public bool IsMoving = false;

    #endregion
    #region Methods
    public void setIsMoving(bool value)
    {
        IsMoving = value;
    }

    public void setMovementStartsRight(bool value)
    {
        MovementStartsRight = value;
    }
    #endregion
}
