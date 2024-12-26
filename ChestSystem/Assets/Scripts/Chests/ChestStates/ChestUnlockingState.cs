using UnityEngine;

public class ChestUnlockingState : ChestState
{
    public ChestUnlockingState(ChestStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public override void Enter()
    {
        // Code to run when entering this state
        Debug.Log("Entered Unlocking State");
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