using System.Collections.Generic;
using UnityEngine;

public class ChestStateMachine : MonoBehaviour
{
    private ChestController owner;
    private Dictionary<ChestStates, ChestState> States = new Dictionary<ChestStates, ChestState>();
    private ChestState currentState;
    private float timeRemaining;
    public float TimeRemaining { get => timeRemaining; set => timeRemaining = value; }
    public ChestState CurrentState
    {
        get => currentState;
        private set { }
    }

    public ChestStates currentStateEnum;

    public ChestStateMachine(ChestController owner)
    {
        this.owner = owner;
        CreateStates();
        SetOwner();
    }

    public void Update()
    {
        currentState?.Execute();
    }

    protected void ChangeState(ChestState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    public void ChangeState(ChestStates newState)
    {
        ChangeState(States[newState]);
        currentStateEnum = newState;
    }

    private void CreateStates()
    {
        States.Add(ChestStates.Locked, new ChestLockedState(this));
        States.Add(ChestStates.Unlocking, new ChestUnlockingState(this));
        States.Add(ChestStates.Unlocked, new ChestUnlockedState(this));
        States.Add(ChestStates.Collected, new ChestCollectedState(this));
    }

    public void SetOwner()
    {
        foreach (var state in this.States.Values)
        {
            state.owner = this.owner;
        }
    }
}   