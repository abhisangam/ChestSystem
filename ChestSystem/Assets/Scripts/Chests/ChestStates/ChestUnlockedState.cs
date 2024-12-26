using UnityEngine;

public class ChestUnlockedState : ChestState
{
    public ChestUnlockedState(ChestStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public override void Enter()
    {
        // Code to run when entering this state
        Debug.Log("Entered Unlocked State");
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