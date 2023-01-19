using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAirborneState : CharacterClass, IAirState
{
    Timer climbTimer = new Timer(.3f); 

    public void OnEnter() 
    {
        character.movement.physicsHandler.SetAccelerationStepCap(.65f);
        character.eventManager.InvokeEvent("InAir");

        character.statsHandler.ResetStatValue("Double Jump Amount");
        climbTimer.ResetTimer();
    }

    public void WhileInState()
    {
        character.movement.physicsHandler.Move(character.movement.input.GetHorizontalInput(), character.statsHandler.GetStat("Speed"), CanJump(), character.statsHandler.GetStat("Jump Force"));
    }

    public void OnExit() { }

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
        else if (character.movement.climbStatus.CanClimb() && (character.movement.input.GetVerticalInput() > .5f || character.movement.input.GetVerticalInput() < -.5f) && climbTimer.IsTimerUp())
        {
            owner.SwitchState("Climb");
        }
    }

    bool CanJump()
    {
        bool jump = character.movement.input.GetJumpInput() && character.statsHandler.GetStat("Double Jump Amount") > 0;

        if (jump)
        {
            character.movement.physicsHandler.SetVelocity(new Vector2(character.movement.physicsHandler.GetVelocity().x, 0));
            character.statsHandler.SubtractStatValue("Double Jump Amount", 1);
            character.eventManager.InvokeEvent("OnJump");
        }

        return jump;
    }
}
