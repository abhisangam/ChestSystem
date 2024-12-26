public class ChestStartUnlockingCommand : ChestCommand
{
    public ChestStartUnlockingCommand(ChestController chest) : base(chest) { }

    public override void Execute()
    {
        chest.StartUnlocking();
    }

    public override void Undo()
    {
        //chest.StopUnlocking();
    }
}