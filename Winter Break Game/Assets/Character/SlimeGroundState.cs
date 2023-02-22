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
        bool move = character.input.GetJumpInput();

        Debug.Log(character.input.GetHorizontalInput());

        if (move)
        {
            Debug.Log(character.statsHandler.GetStat("Speed"));
            character.movement.Move(character.input.GetHorizontalInput(), character.statsHandler.GetStat("Speed"));
            character.movement.Jump(character.statsHandler.GetStat("Jump Height"));
        }
    }

    public void OnExit()
    {

    }

    public void Transition(StateMachine owner)
    {

    }
}
