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

        character.eventManager.AddEventListener("GroundOnTrue", () => SwichState("PlayerGroundedState"));
        character.eventManager.AddEventListener("GroundOnFalse", () => SwichState("PlayerAirborneState"));
        character.eventManager.AddEventListener("WallOnFalse", () => 
        {
            if (character.enviormentStatuses.GetStatus("Ground"))
                SwichState("PlayerGroundedState");
            else
                SwichState("PlayerAirborneState");
        });

        character.eventManager.AddEventListener("WallOnTrue", () => SwichState("PlayerWallState"));
        character.eventManager.AddEventListener("ClimbOnTrue", () => SwichState("PlayerClimbState"));
        character.eventManager.AddEventListener("ClimbOnFalse", () =>
        {
            if (character.enviormentStatuses.GetStatus("Ground"))
                SwichState("PlayerGroundedState");
            else
                SwichState("PlayerAirborneState");
        });
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
        Debug.Log(stateName);
    }
}
