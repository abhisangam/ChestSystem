public class ChestForceUnlockCommand : ChestCommand
{
    private int gems;
    private float timeRemaining;
    public ChestForceUnlockCommand(ChestController chest) : base(chest)
    {
        
    }

    public override void Execute()
    {
        chest.IsForceOpened = true;
        gems = chest.GetGemsNeededToOpen();
        timeRemaining = chest.GetTimeRemaining();
        chest.Unlock();
    }

    public override void Undo()
    {
        //return gems
        //set timer
        chest.RevertForceUnlock(timeRemaining);
    }
}