using UnityEngine;

public class ChestLockedState : ChestState
{
    public ChestLockedState(ChestStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public override void Enter()
    {
        Debug.Log("Entered Locked State");
        stateMachine.TimeRemaining = owner.ChestSO.UnlockTimeInSeconds;
        owner.ChestView.HideTimer();
        owner.ChestView.ShowLocked();
    }

    public override void Execute()
    {
        // Code to run while in this state
    }

    public override void Exit()
    {
        // Code to run when exiting this state
    }
}