using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : CharacterClass, ICharacterMovementHandler
{
    public StateMachine stateMachine; 

    public void Start()
    {
        PlayerGroundedState groundState = new PlayerGroundedState();
        PlayerAirborneState airborneState = new PlayerAirborneState();
        PlayerWallState wallState = new PlayerWallState();
        PlayerClimbState climbState = new PlayerClimbState();

        groundState.Constructer(character);
        airborneState.Constructer(character);
        wallState.Constructer(character);
        climbState.Constructer(character);


        stateMachine = new StateMachine(groundState, airborneState, wallState, climbState);
        stateMachine.SwitchState("PlayerAirborneState");

        character.groundStatus.OnHitGround += () => SwichState("PlayerGroundedState");

        character.groundStatus.OnEnterAir += () => SwichState("PlayerAirborneState");

        character.wallStatus.OnWallExited += () =>
        {
            if (character.groundStatus.IsOnGround())
                SwichState("PlayerGroundedState");
            else
                SwichState("PlayerAirborneState");
        };

        character.wallStatus.OnWallEntered += () => SwichState("PlayerWallState");
        character.climbStatus.OnClimbEnter += () => SwichState("PlayerClimbState");
        character.climbStatus.OnClimbExit += () => {
            if (character.groundStatus.IsOnGround())
                SwichState("PlayerGroundedState");
            else
                SwichState("PlayerAirborneState");
        };
    }

    public void Update()
    {
        stateMachine.InvokeCurrentState();
    }

    public void FixedUpdate()
    {
        stateMachine.InvokeFixedState();
    }

    void SwichState(string stateName) 
    { 
        stateMachine.SwitchState(stateName);
        Debug.Log(stateName);
    }
}
