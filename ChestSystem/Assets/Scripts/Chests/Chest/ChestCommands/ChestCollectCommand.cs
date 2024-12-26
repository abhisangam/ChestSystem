public class ChestCollectCommand : ChestCommand
{
    public ChestCollectCommand(ChestController chest) : base(chest) { }

    public override void Execute()
    {
        chest.Collect();
    }

    public override void Undo()
    {
        //chest.StopUnlocking();
    }
}