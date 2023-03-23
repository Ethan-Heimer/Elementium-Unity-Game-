using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbState : PlayerMovementState
{
    public PlayerClimbState(Character _character, PlayerMovementHandler _playerMovementHandler) : base(_character, _playerMovementHandler) { }

    public override void OnEnter() 
    {
        character.physicsHandler.FreezeGravity(true);
        character.physicsHandler.SetMaxAcceleration(0);
        character.physicsHandler.SetAcceleration(0);
    }

    public override void WhileInState()
    {
        if(character.input.GetJumpInput() && character.input.GetVerticalInput() > .1f)
        {
            character.movement.Jump(playerMovementHandler.JumpHeight);
        }  
    }

    public override void FixedWhileInState()
    {
        Vector2 moveVector = new Vector2(character.input.GetHorizontalInput(), character.input.GetVerticalInput());
        character.movement.AxisMove(new Vector2(character.input.GetHorizontalInput(), character.input.GetVerticalInput()), playerMovementHandler.ClimbSpeed, true);
    }

    public override void OnExit()
    {
        character.physicsHandler.FreezeGravity(false);
    }
}
