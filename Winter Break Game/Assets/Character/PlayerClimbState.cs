using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbState : CharacterClass, IState, IFixedState
{
    bool jumped; 
    public void OnEnter() 
    {
        character.physicsHandler.FreezeGravity(true);
        character.physicsHandler.SetMaxAcceleration(0);
        character.physicsHandler.SetAcceleration(0);
    }

    public void WhileInState()
    {
        if(character.input.GetJumpInput() && character.input.GetVerticalInput() > .1f)
        {
            character.movement.Jump(character.statsHandler.GetStat("Jump Force"));
        }  
    }

    public void FixedWhileInState()
    {
        Vector2 moveVector = new Vector2(character.input.GetHorizontalInput(), character.input.GetVerticalInput());
        character.movement.AxisMove(new Vector2(character.input.GetHorizontalInput(), character.input.GetVerticalInput()), character.statsHandler.GetStat("Climb Speed"), true);
    }

    public void OnExit()
    {
        character.physicsHandler.FreezeGravity(false);
        jumped = false;
    }

    public void Transition(StateMachine owner)
    {
       
    }
}
