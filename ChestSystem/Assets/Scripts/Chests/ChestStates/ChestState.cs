public enum ChestStates
{
    Locked,
    Unlocking,
    Unlocked,
    Collected
}

public abstract class ChestState
{
    public ChestController owner;
    protected ChestStateMachine stateMachine;
    public virtual void Enter()
    {
        // Code to run when entering this state
    }

    public virtual void Execute()
    {
        // Code to run while in this state
    }

    public virtual void Exit()
    {
        // Code to run when exiting this state
    }
}