using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWallState : CharacterClass, IWallState
{
    int dirFacing;
    float inputDir; 
    public void OnEnter()
    {
        character.movement.physicsHandler.SetAccelerationStepCap(1);
        character.eventManager.InvokeEvent("OnWall");
        character.movement.physicsHandler.SetAccelerationStep(0);
    }

    public void WhileInState()
    {
        dirFacing = character.movement.directionHandler.GetCurrentDirection();
        inputDir = character.movement.input.GetHorizontalInput();

        if (character.movement.input.GetJumpInput())
        {
            character.movement.physicsHandler.SetAccelerationStep(-dirFacing);
            character.eventManager.InvokeEvent("OnJump");
            character.movement.physicsHandler.Move(-dirFacing, character.statsHandler.GetStat("Speed"));
            character.movement.physicsHandler.Jump(true, character.statsHandler.GetStat("Jump Force"));
        }
       
    }

    public void FixedWhileInState()
    {
        if (inputDir == dirFacing && character.movement.physicsHandler.GetVelocity().y < 0)
        {
            character.movement.physicsHandler.SetVelocity(new Vector2(character.statsHandler.GetStat("Speed") * dirFacing, -character.statsHandler.GetStat("Speed") / 1.5f));
        }
        else if (inputDir == -dirFacing)
        {
            character.movement.directionHandler.FlipCharacter(-dirFacing);
            character.movement.physicsHandler.SetAccelerationStep(-dirFacing/2);
        }
    }

    public void OnExit() => character.eventManager.InvokeEvent("OffWall");
    public void Transition(StateMachine owner)
    {
        if (character.movement.groundStatus.IsOnGround())
        {
            owner.SwitchState("Ground");
        }
        else if(!character.movement.groundStatus.IsOnGround() && !character.movement.wallStatus.IsOnWall())
        {
            owner.SwitchState("Air");
        }
    }
}
