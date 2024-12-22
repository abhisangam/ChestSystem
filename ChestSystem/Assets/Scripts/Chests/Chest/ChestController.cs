using System;

public class ChestController
{
    private ChestView chestView;
    private int chestSlotID;

    public Action<int> OnChestClicked;
    public ChestController(ChestView chestView, int chestSlotID)
    {
        this.chestView = chestView;
        this.chestSlotID = chestSlotID;

        this.chestView.OnChestClicked += () => OnChestClicked?.Invoke(this.chestSlotID);
    }
}