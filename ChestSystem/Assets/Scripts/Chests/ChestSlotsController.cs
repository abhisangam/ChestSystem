using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlotsController
{
    private ChestSlotsView chestSlotsView;
    private List<ChestController?> chestSlots;

    public ChestSlotsController(ChestSlotsView chestSlotsView)
    {
        this.chestSlotsView = chestSlotsView;
        chestSlots = new List<ChestController?>();

        for(int i = 0; i < GameConfig.Instance.InitialChestSlots; i++)
        {
            AddChestSlot();
        }
    }

    public void AddChestSlot()
    {
        if(chestSlots.Count >= GameConfig.Instance.MaxChestSlots) return;
        chestSlots.Add(null);
        chestSlotsView.AddChestSlot();
    }

    public void AddChest(ChestSO chestSO)
    {
        int index = chestSlots.FindIndex(x => x == null);
        if (index < 0) return;

        chestSlots[index] = CreateChest(chestSO, index);
    }

    private ChestController CreateChest(ChestSO chestSO, int chestSlotID)
    {
        ChestView chestView = new ChestView(chestSO.AnimatedChest);
        chestSlotsView.AddChest(chestView, chestSlotID);
        return new ChestController(chestView, chestSlotID);
    }
}
