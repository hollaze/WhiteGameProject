using UnityEngine;

public class UnitState : MonoBehaviour
{
    #region Enums
    public enum UnitMovementState
    {
        Walk,
        Dash,
        KnockedOut
    }

    public enum UnitLiveState
    {
        Alive,
        Dead
    }
    #endregion

    public static UnitState instance;

    [Tooltip("Current unit movement state")]
    public UnitMovementState unitMovementState;

    void Awake()
    {
        #region Singleton
        if (instance != null)
        {
            Debug.LogError("More than one instance of " + this.name);
            return;
        }

        instance = this;
        #endregion

        unitMovementState = UnitMovementState.Walk;
    }

    void Update()
    {
        switch (unitMovementState)
        {
            case UnitMovementState.Walk:
                break;
            case UnitMovementState.Dash:
                break;
            case UnitMovementState.KnockedOut:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Check if given state match with the current state
    /// </summary>
    /// <param name="unitMovementState"></param>
    /// <returns>true if it matches, false otherwise</returns>
    public bool IsState(UnitMovementState? unitMovementState)
    {
        if (this.unitMovementState == unitMovementState)
        {
            return true;
        }

        return false;
    }
}
