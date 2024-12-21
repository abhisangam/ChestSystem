using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlotsView : MonoBehaviour
{
    [SerializeField] private GameObject chestSlotPrefab;
    [SerializeField] private Transform chestSlotsParent;
    private List<GameObject> chestSlots;

    public void AddChestSlot()
    {
        GameObject chestSlot = Instantiate(chestSlotPrefab, chestSlotsParent);
        chestSlots.Add(chestSlot);
    }

    public void AddChest(ChestView chestView, int chestSlotID)
    {
        chestView.transform.parent = chestSlots[chestSlotID].transform;
    }
}
