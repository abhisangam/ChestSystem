using System.Collections.Generic;

public class ChestStateMachine
{
    private ChestController Owner;
    private Dictionary<ChestStates, ChestState> States = new Dictionary<ChestStates, ChestState>();
    private ChestState CurrentState;

    public ChestStateMachine(ChestController owner)
    {
        //Owner = owner;
        //CurrentState = States[ChestStates.Locked];
        //CurrentState.Enter();
    }

    public void ChangeState(ChestStates newState)
    {
        //CurrentState.Exit();
        //CurrentState = States[newState];
        //CurrentState.Enter();
    }

    public void SetOwner()
    {
        //
    }
}   