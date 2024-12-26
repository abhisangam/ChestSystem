using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlotsController
{
    private ChestSlotsView chestSlotsView;
    private ChestInfoPopupController chestInfoPopupController;
    private List<ChestController?> chestSlots;

    private ChestCommand? lastComand;

    public ChestSlotsController(ChestSlotsView chestSlotsView, ChestInfoPopupController chestInfoPopupController)
    {
        this.chestSlotsView = chestSlotsView;
        chestSlots = new List<ChestController?>();

        for (int i = 0; i < GameConfig.Instance.InitialChestSlots; i++)
        {
            AddChestSlot();
        }

        this.chestInfoPopupController = chestInfoPopupController;
        this.chestInfoPopupController.OnChestAction += OnChestAction;
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
        return new ChestController(chestView, chestSlotID, chestSO);
    }

    private void OnChestClicked(int chestSlotID)
    {
        //Open chest info popup
        Debug.Log("Chest clicked: " + chestSlotID);
        chestInfoPopupController.Show(chestSlots[chestSlotID], !IsOtherChestOpening(chestSlotID));

    }

    private bool IsOtherChestOpening(int chestSlotID)
    {
        foreach (var chest in chestSlots)
        {
            if(chest == null) continue;
            if (chest.GetChestState() != ChestStates.Locked && chest.ChestSlotID != chestSlotID)
            {
                return false;
            }
        }
        return true;
    }

    private void OnChestAction(ChestAction chestAction, int chestSlotID)
    {
        chestInfoPopupController.Hide();
        switch (chestAction)
        {
            case ChestAction.StartUnlocking:
                lastComand = new ChestStartUnlockingCommand(chestSlots[chestSlotID]);
                lastComand.Execute();
                break;
            case ChestAction.UnlockNow:
                lastComand = new ChestForceUnlockCommand(chestSlots[chestSlotID]);
                lastComand.Execute();
                break;
            case ChestAction.RevertForceUnlock:
                if(lastComand != null && lastComand is ChestForceUnlockCommand)
                {
                    lastComand.Undo();
                    lastComand = null;
                }
                break;
            case ChestAction.Collect:
                lastComand = new ChestCollectCommand(chestSlots[chestSlotID]);
                lastComand.Execute();
                break;
        }
    }
}
