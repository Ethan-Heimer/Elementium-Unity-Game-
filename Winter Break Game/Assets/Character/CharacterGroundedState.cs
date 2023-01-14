using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class CharacterGroundedState : CharacterClass, IGroundState
{
    public void OnEnter()
    {
        character.movement.physicsHandler.SetAccelerationStepCap(1);
        character.eventManager.InvokeEvent("OnGround");
    }
    public void WhileInState()
    {
        float xInput = character.movement.input.GetHorizontalInput();
        CheckWalking(xInput);

        character.movement.physicsHandler.Move(xInput, character.statsHandler.GetStat("Speed"), CanJump(), character.statsHandler.GetStat("Jump Force"));
    }
    public void OnExit()
    {
        CheckWalking(0);
    }

    public void Transition(StateMachine owner)
    {
        if (!character.movement.groundStatus.IsOnGround())
        {
            if (character.movement.wallStatus.IsOnWall())
            {
                owner.SwitchState("Wall");
            }

            else
            {
                owner.SwitchState("Air");
            }
        }
        else if (character.movement.climbStatus.CanClimb() && (character.movement.input.GetVerticalInput() > .5f || character.movement.input.GetVerticalInput() < -.5f))
        {
            owner.SwitchState("Climb"); 
        }
    }

    bool CanJump()
    {

        if (character.movement.input.GetJumpInput())
        {
            character.eventManager.InvokeEvent("OnJump");
        }

        return character.movement.input.GetJumpInput();
    }

    bool isWalking; 
    void CheckWalking(float input)
    {
        if(input is not 0 && !isWalking)
        {
            isWalking = true;
            character.eventManager.InvokeEvent("OnStartWalk");
        }
        else if(input is 0 && isWalking)
        {
            isWalking = false;
            character.eventManager.InvokeEvent("OnEndWalk");
        }
    }
}