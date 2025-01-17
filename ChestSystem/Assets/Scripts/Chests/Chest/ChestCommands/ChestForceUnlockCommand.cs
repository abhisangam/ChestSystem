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
        GameService.Instance.PlayerController.DeductGems(gems);
        chest.Unlock();
    }

    public override void Undo()
    {
        GameService.Instance.PlayerController.AddGems(gems);
        chest.RevertForceUnlock(timeRemaining);
    }
}