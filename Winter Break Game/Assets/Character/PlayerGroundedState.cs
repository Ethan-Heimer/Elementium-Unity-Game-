using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class PlayerGroundedState : CharacterClass, IGroundState
{
    float xInput; 

    public void OnEnter()
    {
        character.physicsHandler.SetMaxAcceleration(1);
    }
    public void WhileInState()
    {
        if(character.input.GetJumpInput())
            character.movement.Jump(character.statsHandler.GetStat("Jump Force")); 
    }

    public void FixedWhileInState()
    {
        xInput = character.input.GetHorizontalInput();

        if(character.wallStatus.IsOnWall()) character.physicsHandler.SetAcceleration(0);

        character.movement.Move(xInput, character.statsHandler.GetStat("Speed"));
    }

    public void OnExit() { }

    public void Transition(StateMachine owner)
    {
        if (!character.groundStatus.IsOnGround())
        {
            if (character.wallStatus.IsOnWall())
            {
                owner.SwitchState("Wall");
            }

            else
            {
                owner.SwitchState("Air");
            }
        }
        else if (character.climbStatus.CanClimb() && (character.input.GetVerticalInput() > .5f || character.input.GetVerticalInput() < -.5f))
        {
            owner.SwitchState("Climb"); 
        }
    }
}