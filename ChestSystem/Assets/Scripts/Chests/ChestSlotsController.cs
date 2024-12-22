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
        chestSlots[index].OnChestClicked += OnChestClicked;
    }

    private ChestController CreateChest(ChestSO chestSO, int chestSlotID)
    {
        ChestView chestView = chestSlotsView.AddChest(chestSlotID, chestSO.animatedChestPrefab);
        return new ChestController(chestView, chestSlotID);
    }

    private void OnChestClicked(int chestSlotID)
    {
        //Open chest info popup
        Debug.Log("Chest clicked: " + chestSlotID);

    }
}
