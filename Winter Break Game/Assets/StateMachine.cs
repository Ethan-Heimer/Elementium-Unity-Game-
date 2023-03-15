using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System; 

public class StateMachine
{
    protected IState currentState;
    protected IFixedState currentStateFixedInvoker; 

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

    public virtual void SwitchState(string name)
    {
        currentState?.OnExit();

        IState newState = null; 

        try
        {
            newState = possableStates.First(x => x.GetType().Name == name);
            if (newState is IFixedState) currentStateFixedInvoker = newState as IFixedState; 
        }
        catch (InvalidOperationException)
        {
            Debug.LogError("State Does Not Exist -- State Will Stay The Same \n transition from:" +currentState.GetType().Name);
            return;
        }

        currentState = newState; 
        currentState.OnEnter();
    }

    public void InvokeCurrentState()
    {
        currentState?.WhileInState();
    }

    public void InvokeFixedState()
    {
        currentStateFixedInvoker?.FixedWhileInState();
    }
}