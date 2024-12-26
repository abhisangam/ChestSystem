public abstract class ChestCommand : ICommand
{
    protected ChestController chest;

    public ChestCommand(ChestController chest)
    {
        this.chest = chest;
    }

    public abstract void Execute();

    public abstract void Undo();
}