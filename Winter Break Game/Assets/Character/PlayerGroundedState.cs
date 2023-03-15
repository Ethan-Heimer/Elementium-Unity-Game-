using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class PlayerGroundedState : CharacterClass, IState, IFixedState
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
      
    }
}