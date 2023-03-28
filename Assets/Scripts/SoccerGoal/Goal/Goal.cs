public class Goal
{
    #region Properties and fields

    public bool IsGoalEnabled = true;
    public bool IsRandomMovementEnable = true;
    public float TargetSpeed = 4f;
    public float ZminValue = -5;
    public float ZmaxValue = 5;
    public float WaitingTime = 1f;
    public bool MovementStartsRight = false;
    public bool IsMoving = false;

    #endregion
    #region Methods
    public void setIsMoving( bool value )
    {
        IsMoving = value;
    }

    public void setMovementStartsRight(bool value)
    {
        MovementStartsRight = value;
    }
    #endregion
}
