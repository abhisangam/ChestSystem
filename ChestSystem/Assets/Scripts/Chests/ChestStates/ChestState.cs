public enum ChestStates
{
    Locked,
    Unlocking,
    Unlocked,
    Collected
}

public class ChestState : IState
{
    private ChestController Owner;
    public void Enter()
    {
        // Code to run when entering this state
    }

    public void Execute()
    {
        // Code to run while in this state
    }

    public void Exit()
    {
        // Code to run when exiting this state
    }
}