using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System; 

public class StateMachine
{
    IState currentState;

    IState[] possableStates; 

    public StateMachine(params IState[] _possableStates)
    {
        possableStates = _possableStates; 
    }
    
    public StateMachine(string defalutStateName, params IState[] _possableStates)
    {
        possableStates = _possableStates; 

        SwitchState(defalutStateName); 
    }

    public void SwitchState(string name)
    {
        currentState?.OnExit(this);

        IState newState = null; 

        try
        {
            newState = possableStates.First(x => x.GetType().Name == name);
        }
        catch (InvalidOperationException e)
        {
            Debug.LogError("State Does Not Exist -- State Will Stay The Same \n transition from:" +currentState.GetType().Name);
            return;
        }

        currentState = newState; 
        currentState.OnEnter(this);
    }

    public void InvokeCurrentState()
    {
        currentState?.WhileInState(this);
        currentState.Transition(this);
    }
}