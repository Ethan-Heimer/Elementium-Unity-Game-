using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWallState : CharacterClass, IWallState
{
    public void OnEnter()
    {
        character.movement.physicsHandler.SetAccelerationStepCap(1);
        character.eventManager.InvokeEvent("OnWall");
    }

    public void WhileInState()
    {
        int dirFacing = character.movement.directionHandler.GetCurrentDirection();
        float inputDir = character.movement.input.GetHorizontalInput();

        if(inputDir == dirFacing && character.movement.physicsHandler.GetVelocity().y < 0)
        {
            character.movement.physicsHandler.SetVelocity(new Vector2(character.statsHandler.GetStat("Speed") * dirFacing, -character.statsHandler.GetStat("Speed") / 1.5f));
        }
        else if(inputDir == -dirFacing)
        {
            character.movement.directionHandler.FlipCharacter(-dirFacing);
            character.movement.physicsHandler.SetAccelerationStep(0);
        }

        if (character.movement.input.GetJumpInput())
        {
            character.movement.physicsHandler.SetAccelerationStep(-dirFacing);
            character.eventManager.InvokeEvent("OnJump");
            character.movement.physicsHandler.Move(-dirFacing, character.statsHandler.GetStat("Speed"), true, character.statsHandler.GetStat("Jump Force"));
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
