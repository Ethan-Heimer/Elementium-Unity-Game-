using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallState : PlayerMovementState
{
    int dirFacing;
    float inputDir;

    bool jumped; 

    public PlayerWallState(Character character, PlayerMovementHandler playerMovementHandler) : base(character, playerMovementHandler) { }
    

    public override void OnEnter()
    {
        character.physicsHandler.SetMaxAcceleration(1f);
        character.physicsHandler.SetAcceleration(0);

        character.physicsHandler.SetVelocity(Vector2.up * character.physicsHandler.GetVelocity());
    }

    public override void WhileInState()
    {
        dirFacing = character.directionHandler.GetCurrentDirection();
        inputDir = character.input.GetHorizontalInput();

        if (character.input.GetJumpInput())
        {
            character.physicsHandler.SetAcceleration(-dirFacing);
            character.movement.Move(-dirFacing, playerMovementHandler.Speed);
            character.movement.Jump(playerMovementHandler.WallJumpForce);

            jumped = true;
        }
    }

    public override void FixedWhileInState()
    {
        if (jumped) return;

        if (Mathf.RoundToInt(inputDir) == dirFacing && character.physicsHandler.GetVelocity().y < 0)
        {
            character.movement.AxisMove(new Vector2(0, -1f), playerMovementHandler.WallSlipSpeed, false);
        }
        else if (Mathf.RoundToInt(inputDir) == -dirFacing)
        {
            character.directionHandler.FlipCharacter(inputDir);
            character.physicsHandler.SetAcceleration(inputDir/2);
            character.movement.Move(inputDir, playerMovementHandler.Speed);
        }
    }

    public override void OnExit() 
    { 
        jumped = false; 
    }
}
