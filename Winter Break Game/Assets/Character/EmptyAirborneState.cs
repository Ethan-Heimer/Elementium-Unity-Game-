using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyAirborneState : CharacterClass, IAirState
{
    public void OnEnter()
    {

    }

    public void WhileInState()
    {

    }

    public void FixedWhileInState()
    {

    }

    public void OnExit()
    {

    }

    public void Transition(StateMachine owner)
    {
        if (character.movement.groundStatus.IsOnGround())
        {
            owner.SwitchState("Ground");
        }
        else if (character.movement.wallStatus.IsOnWall())
        {
            owner.SwitchState("Wall");
        }
        else if (character.movement.climbStatus.CanClimb() && (character.movement.input.GetVerticalInput() > .5f || character.movement.input.GetVerticalInput() < -.5f))
        {
            owner.SwitchState("Climb");
        }
    }
}
