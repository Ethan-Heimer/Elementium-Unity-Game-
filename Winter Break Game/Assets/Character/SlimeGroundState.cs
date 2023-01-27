using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGroundState : CharacterClass, IGroundState
{
    public void OnEnter()
    {

    }

    public void WhileInState()
    {
       
    }


    public void FixedWhileInState()
    {
        bool move = character.movement.input.GetJumpInput();

        if (move)
        {
            character.movement.physicsHandler.Move(character.movement.input.GetHorizontalInput(), character.statsHandler.GetStat("Jump Height"));
            character.movement.physicsHandler.Jump(true, character.statsHandler.GetStat("Speed"));
        }
    }

    public void OnExit()
    {

    }

    public void Transition(StateMachine owner)
    {

    }
}
