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
        stateMachine.SwitchState("PlayerGroundedState");
    }

    public void Update()
    {
        stateMachine.InvokeCurrentState();
    }

    public void FixedUpdate()
    {
        stateMachine.InvokeFixedState();
    }
}
