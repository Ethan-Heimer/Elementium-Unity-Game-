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
        bool move = character.movement.input.GetJumpInput(); 

        if(move)
        {
            character.movement.physicsHandler.Move(character.movement.input.GetHorizontalInput(), character.statsHandler.GetStat("Speed"), true, character.statsHandler.GetStat("Jump Height"));
            Debug.Log(character.movement.input.GetHorizontalInput());
        }    
       
    }

    public void OnExit()
    {

    }

    public void Transition(StateMachine owner)
    {

    }
}
