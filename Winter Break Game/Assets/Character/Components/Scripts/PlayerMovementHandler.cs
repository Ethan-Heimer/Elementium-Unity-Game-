using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Movement Handler", menuName = "Character Components/Movement Handlers/Player Movement Handler")]
public class PlayerMovementHandler : CharacterMovementHandler
{
    public StateMachine stateMachine;

    public float Speed;
    public float JumpHeight;
    public float ClimbSpeed;
    public float InAirAirResistance;
    public float DoubleJumpAmount;
    public float WallJumpForce;
    public float WallSlipSpeed;

    public override void OnStart(Character character)
    {
        PlayerGroundedState groundState = new PlayerGroundedState(character, this);
        PlayerAirborneState airborneState = new PlayerAirborneState(character, this);
        PlayerWallState wallState = new PlayerWallState(character, this);
        PlayerClimbState climbState = new PlayerClimbState(character, this);

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

    public override void OnUpdate(Character character)
    {
        stateMachine.InvokeCurrentState();
    }

    public override void OnFixedUpdate(Character character)
    {
        stateMachine.InvokeFixedState();
    }

    void SwichState(string stateName) 
    { 
        stateMachine.SwitchState(stateName);
    }
}
