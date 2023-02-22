using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System; 

public class StateMachine
{
    protected IState currentState;

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
        currentState?.Transition(this);
    }
}

public class CharacterStateMachiene : StateMachine
{
    Character character;

    IGroundState groundState;
    IAirState airState;
    IWallState wallState;
    IClimbState climbState;

    public CharacterStateMachiene(IGroundState _groundState, IAirState _airState, IWallState _wallState, IClimbState _climbState, Character _character)
    {
        groundState = _groundState;
        airState = _airState;
        wallState = _wallState;
        climbState = _climbState;

        groundState.Constructer(_character);
        airState.Constructer(_character);
        wallState.Constructer(_character);
        climbState.Constructer(_character);

        currentState = groundState;

        character = _character; 
    }

    public override void SwitchState(string name)
    {
        ICharacterState newState = null; 

        if(currentState == groundState)
        {
            character.eventManager.OnEndMove.Invoke();
        }
        else if(currentState == wallState)
        {
            character.eventManager.OffWall.Invoke();
        }

        switch (name)
        {
            case "Ground":
                if (groundState is not null)
                {
                    newState = groundState;
                    character.eventManager.OnGround.Invoke();
                }
                else
                {
                    Debug.LogError("Ground State Not Provided");
                    return;
                }
            break;

            case "Air":
                if (airState is not null)
                {
                    character.eventManager.InAir.Invoke();
                    newState = airState;
                }
                else
                {
                    Debug.Log("Air State Not Provided");
                    return; 
                }
            break;

            case "Wall":
                if (wallState is not null)
                {
                    newState = wallState;
                    character.eventManager.OnWall.Invoke();
                }
                else
                {
                    Debug.Log("Wall State Not Provided");
                    return;
                }
            break;

            case "Climb":
                if (climbState is not null)
                {
                    newState = climbState;
                    character.eventManager.OnStartClimb.Invoke();
                }
                else
                {
                    Debug.Log("Climb State Not Provided");
                    return;
                }
            break;

            default:
                Debug.LogError("State Does Not Exist");
                break;
        }

        currentState?.OnExit();
        currentState = newState; 
        currentState?.OnEnter();
    }

    public void InvokeFixedState()
    {
        (currentState as ICharacterState).FixedWhileInState();
    }
}