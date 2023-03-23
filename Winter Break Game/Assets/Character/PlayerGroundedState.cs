using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class PlayerGroundedState : PlayerMovementState
{
    float xInput; 

    public PlayerGroundedState(Character character, PlayerMovementHandler playerMovementState) : base(character, playerMovementState) { }
   
    public override void OnEnter()
    {
        character.physicsHandler.SetMaxAcceleration(1);
    }
    public override void WhileInState()
    {
        if(character.input.GetJumpInput())
            character.movement.Jump(playerMovementHandler.JumpHeight); 
    }

    public override void FixedWhileInState()
    {
        xInput = character.input.GetHorizontalInput();

        if(character.wallStatus.IsOnWall()) character.physicsHandler.SetAcceleration(0);

        character.movement.Move(xInput, playerMovementHandler.Speed);
    }

    public override void OnExit() { }
}