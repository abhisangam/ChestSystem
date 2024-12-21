using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<ChestSO> chestTypes;
    [SerializeField] private Button addChestSlotButton;
    [SerializeField] private Button addChestButton;
    void Start()
    {
        addChestButton.onClick.AddListener(AddChest);
        addChestSlotButton.onClick.AddListener(AddChestSlot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddChestSlot()
    {
        // Add a new chest slot to the player's inventory
    }

    private void AddChest()
    {
        // Add a new chest slot
    }
}
