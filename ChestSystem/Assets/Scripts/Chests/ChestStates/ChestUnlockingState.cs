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
        owner.ChestView.ShowTimer();
        owner.ChestView.ShowUnlocking();
    }

    public override void Execute()
    {
        // Code to run while in this state
        this.stateMachine.TimeRemaining -= Time.deltaTime;
        owner.SetTimeRemaining(this.stateMachine.TimeRemaining);
        owner.SetGemsToUnlock();
        if (this.stateMachine.TimeRemaining < 0)
        {
            owner.Unlock();
        }
    }

    public override void Exit()
    {
        // Code to run when exiting this state
    }
}