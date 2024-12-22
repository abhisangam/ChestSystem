using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSlotsView : MonoBehaviour
{
    [SerializeField] private GameObject chestSlotPrefab;
    [SerializeField] private Transform chestSlotsParent;
    [SerializeField] private ChestView chestPrefab;
    private List<GameObject> chestSlots;

    private void Awake()
    {
        chestSlots = new List<GameObject>();
    }

    public void AddChestSlot()
    {
        GameObject chestSlot = Instantiate(chestSlotPrefab, chestSlotsParent);
        chestSlots.Add(chestSlot);
    }

    public ChestView AddChest(int chestSlotID, AnimatedChest animatedChestPrefab)
    {
        ChestView chestView = Instantiate<ChestView>(chestPrefab, chestSlots[chestSlotID].transform);
        AnimatedChest animatedhest = Instantiate<AnimatedChest>(animatedChestPrefab, chestView.transform);
        animatedhest.transform.SetAsFirstSibling();
        chestView.transform.SetParent(chestSlots[chestSlotID].transform);
        return chestView;
    }
}
