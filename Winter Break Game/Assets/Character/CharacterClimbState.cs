using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClimbState : CharacterClass, IClimbState
{
    bool isClimbing;
   
    public void OnEnter() 
    {
        character.movement.physicsHandler.FreezeGravity(true);
        character.movement.physicsHandler.SetAccelerationStep(0);
    }

    public void WhileInState()
    {
        Vector2 moveVector = new Vector2(character.movement.input.GetHorizontalInput(), character.movement.input.GetVerticalInput());

        InvokeEvents(moveVector);

        character.movement.physicsHandler.Move(new Vector2(character.movement.input.GetHorizontalInput(), character.movement.input.GetVerticalInput()), character.statsHandler.GetStat("Speed"), character.movement.input.GetJumpInput() && character.movement.input.GetVerticalInput() > .1f, character.statsHandler.GetStat("Jump Force"));
    }

    public void OnExit()
    {
        character.movement.physicsHandler.FreezeGravity(false);
        isClimbing = false; 
    }

    public void Transition(StateMachine owner)
    {
        if (!character.movement.climbStatus.CanClimb() || character.movement.input.GetJumpInput())
        {
            owner.SwitchState("Air"); 
        }
    }
    private void InvokeEvents(Vector2 moveVector)
    {
        if (moveVector == Vector2.zero && isClimbing)
        {
            isClimbing = false;
            character.eventManager.InvokeEvent("OnClimbIdle");
        }
        else if (moveVector != Vector2.zero && !isClimbing)
        {
            isClimbing = true;
            character.eventManager.InvokeEvent("OnClimbing");
        }
    }
}
