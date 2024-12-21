public class ChestController
{
    private ChestView chestView;
    private int chestSlotID;
    public ChestController(ChestView chestView, int chestSlotID)
    {
        this.chestView = chestView;
        this.chestSlotID = chestSlotID;
    }
}