using System;
using UnityEngine;

public class ChestController
{
    private ChestView chestView;
    private int chestSlotID;

    private ChestStateMachine stateMachine;
    private ChestSO chestSO;
    public ChestSO ChestSO { get => chestSO; private set { } }
    public int ChestSlotID { get => chestSlotID; private set { } }

    private bool isForceOpened = false;
    public bool IsForceOpened { get => isForceOpened; set => isForceOpened = value; }


    public Action<int> OnChestClicked;
    public ChestController(ChestView chestView, int chestSlotID, ChestSO chestSO)
    {
        this.chestView = chestView;
        this.chestSlotID = chestSlotID;
        this.chestSO = chestSO;

        Initialize(chestSlotID);
    }

    private void Initialize(int chestSlotID)
    {
        this.chestView.OnChestClicked += () => OnChestClicked?.Invoke(this.chestSlotID);
        this.chestView.OnUpdate += Update;

        stateMachine = new ChestStateMachine(this);
        stateMachine.ChangeState(ChestStates.Locked);
        chestView.SetController(this);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public ChestStates GetChestState()
    {
        return stateMachine.currentStateEnum;
    }

    public void StartUnlocking()
    {
        stateMachine.ChangeState(ChestStates.Unlocking);
    }

    public void Unlock()
    {
        stateMachine.ChangeState(ChestStates.Unlocked);
    }

    public void RevertForceUnlock(float timeToUnlock)
    {
        SetTimeRemaining(timeToUnlock);
        this.IsForceOpened = false;
        stateMachine.ChangeState(ChestStates.Unlocking);
    }

    public void Collect()
    {
        stateMachine.ChangeState(ChestStates.Collected);
    }

    public void GetGemsNeededToOpen()
    {
        //1 gem for every 10 seconds
        int gems = (int)Mathf.Ceil(stateMachine.TimeRemaining / 10.0f);

    }
    public float GetTimeRemaining()
    {
        return stateMachine.TimeRemaining;
    }

    public void SetTimeRemaining(float timeToUnlock)
    {
        stateMachine.TimeRemaining = timeToUnlock;
        chestView.SetTimeRemaining(timeToUnlock);
    }
}