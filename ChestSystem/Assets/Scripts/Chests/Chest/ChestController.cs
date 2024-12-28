using System;
using UnityEngine;

public class ChestController
{
    private ChestView chestView;
    public ChestView ChestView { get => chestView; private set { } }

    private int chestSlotID;

    private ChestStateMachine stateMachine;
    private ChestSO chestSO;
    public ChestSO ChestSO { get => chestSO; private set { } }
    public int ChestSlotID { get => chestSlotID; private set { } }

    private bool isForceOpened = false;
    public bool IsForceOpened { get => isForceOpened; set => isForceOpened = value; }

    public Action OnChestUnlocked;
    public Action<int, int, int> OnChestCollected; //send with index, coins, gems


    public Action<int> OnChestClicked;
    public ChestController(ChestView chestView, int chestSlotID, ChestSO chestSO)
    {
        this.chestView = chestView;
        this.chestSlotID = chestSlotID;
        this.chestSO = chestSO;

        this.chestView.SetController(this);

        Initialize(chestSlotID);
    }

    private void Initialize(int chestSlotID)
    {
        this.chestView.OnChestClicked += () => OnChestClicked?.Invoke(this.chestSlotID);
        this.chestView.OnUpdate += Update;

        stateMachine = new ChestStateMachine(this);
        stateMachine.ChangeState(ChestStates.Locked);
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
        OnChestUnlocked?.Invoke();
    }

    public void RevertForceUnlock(float timeToUnlock)
    {
        SetTimeRemaining(timeToUnlock);
        this.IsForceOpened = false;
        stateMachine.ChangeState(ChestStates.Unlocking);
    }

    public void Collect(int coinsRewarded, int gemsRewarded)
    {
        stateMachine.ChangeState(ChestStates.Collected);
        OnChestCollected?.Invoke(chestSlotID, coinsRewarded, gemsRewarded);
    }

    public int GetGemsNeededToOpen()
    {
        //1 gem for every 10 seconds
        int gems = (int)Mathf.Ceil(stateMachine.TimeRemaining / 10.0f);
        return gems;

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

    public void SetGemsToUnlock()
    {
        this.chestView.SetGemsNeededToUnlock(GetGemsNeededToOpen());
    }

    public void DestroyView()
    {
        GameObject.Destroy(chestView.gameObject);
    }
}