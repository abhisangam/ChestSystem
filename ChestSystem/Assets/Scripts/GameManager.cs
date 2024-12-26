using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<ChestSO> chestTypes;
    [SerializeField] private Button addChestSlotButton;
    [SerializeField] private Button addChestButton;

    [SerializeField] private ChestSlotsView chestSlotsView;
    [SerializeField] private ChestInfoPopupController chestInfoPopupController;
    private ChestSlotsController chestSlotsController;

    void Start()
    {
        addChestButton.onClick.AddListener(AddChest);
        addChestSlotButton.onClick.AddListener(AddChestSlot);

        chestSlotsController = new ChestSlotsController(chestSlotsView, chestInfoPopupController);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddChestSlot()
    {
        chestSlotsController.AddChestSlot();
    }

    private void AddChest()
    {
        chestSlotsController.AddChest(chestTypes[Random.Range(0, chestTypes.Count)]);
    }
}
