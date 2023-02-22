using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClimbState : CharacterClass, IClimbState
{
    public void OnEnter() 
    {
        character.physicsHandler.FreezeGravity(true);
        character.physicsHandler.SetMaxAcceleration(0); 
    }

    public void WhileInState()
    {
        if(character.input.GetJumpInput() && character.input.GetVerticalInput() > .1f)
            character.movement.Jump(character.statsHandler.GetStat("Jump Force")); 
    }

    public void FixedWhileInState()
    {
        Vector2 moveVector = new Vector2(character.input.GetHorizontalInput(), character.input.GetVerticalInput());
        character.movement.Climb(new Vector2(character.input.GetHorizontalInput(), character.input.GetVerticalInput()), character.statsHandler.GetStat("Climb Speed"));
    }

    public void OnExit()
    {
        character.physicsHandler.FreezeGravity(false);
    }

    public void Transition(StateMachine owner)
    {
        if (!character.climbStatus.CanClimb() || character.input.GetJumpInput())
        {
            owner.SwitchState("Air"); 
        }
    }
}
