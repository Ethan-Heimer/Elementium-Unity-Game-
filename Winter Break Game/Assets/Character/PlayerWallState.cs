using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallState : CharacterClass, IState, IFixedState
{
    int dirFacing;
    float inputDir;

    bool jumped; 
    public void OnEnter()
    {
        character.physicsHandler.SetMaxAcceleration(1f);
        character.physicsHandler.SetAcceleration(0);

        character.physicsHandler.SetVelocity(Vector2.up * character.physicsHandler.GetVelocity());
    }

    public void WhileInState()
    {
        dirFacing = character.directionHandler.GetCurrentDirection();
        inputDir = character.input.GetHorizontalInput();

        if (character.input.GetJumpInput())
        {
            character.physicsHandler.SetAcceleration(-dirFacing);
            character.movement.Move(-dirFacing, character.statsHandler.GetStat("Speed"));
            character.movement.Jump(character.statsHandler.GetStat("Wall Jump Force"));

            jumped = true;
        }
    }

    public void FixedWhileInState()
    {
        if (jumped) return;

        if (Mathf.RoundToInt(inputDir) == dirFacing && character.physicsHandler.GetVelocity().y < 0)
        {
            character.movement.AxisMove(new Vector2(0, -1f), character.statsHandler.GetStat("Wall Slip Speed"), false);
        }
        else if (Mathf.RoundToInt(inputDir) == -dirFacing)
        {
            character.directionHandler.FlipCharacter(inputDir);
            character.physicsHandler.SetAcceleration(inputDir/2);
            character.movement.Move(inputDir, character.statsHandler.GetStat("Speed"));
        }
    }

    public void OnExit() 
    { 
        jumped = false; 
    }
    public void Transition(StateMachine owner)
    {
      
    }
}
