using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallState : CharacterClass, IState, IFixedState
{
    int dirFacing;
    float inputDir; 
    public void OnEnter()
    {
        character.physicsHandler.SetMaxAcceleration(1f);
        character.physicsHandler.SetAcceleration(0);

        character.eventManager.OnWall.Invoke();
    }

    public void WhileInState()
    {
        dirFacing = character.directionHandler.GetCurrentDirection();
        inputDir = character.input.GetHorizontalInput();

        if (character.input.GetJumpInput())
        {
            character.physicsHandler.SetAcceleration(-dirFacing);
            character.movement.Move(-dirFacing, character.statsHandler.GetStat("Speed"));
            character.movement.Jump(character.statsHandler.GetStat("Jump Force"));
        }
       
    }

    public void FixedWhileInState()
    {
        if (inputDir == dirFacing && character.physicsHandler.GetVelocity().y < 0)
        {
            character.movement.Climb(new Vector2(dirFacing, -1f), character.statsHandler.GetStat("Wall Slip Speed"), false);
        }
        else if (inputDir == -dirFacing)
        {
            character.directionHandler.FlipCharacter(-dirFacing);
            character.physicsHandler.SetAcceleration(-dirFacing / 2);
        }
    }

    public void OnExit() {}
    public void Transition(StateMachine owner)
    {
        if (character.groundStatus.IsOnGround())
        {
            owner.SwitchState("PlayerGroundedState");
            character.eventManager.OffWall.Invoke();
        }
        else if(!character.groundStatus.IsOnGround() && !character.wallStatus.IsOnWall())
        {
            owner.SwitchState("PlayerAirborneState");
            character.eventManager.OffWall.Invoke();
        }
    }
}
