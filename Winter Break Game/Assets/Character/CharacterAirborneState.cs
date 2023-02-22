using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAirborneState : CharacterClass, IAirState
{
    Timer climbTimer = new Timer(.5f);

    public void OnEnter() 
    {
        character.physicsHandler.SetMaxAcceleration(character.statsHandler.GetStat("Air Resistance"));

        character.statsHandler.ResetStatValue("Double Jump Amount");
        climbTimer.ResetTimer();
    }

    public void WhileInState()
    {
        TryJump();       
    }

    public void FixedWhileInState()
    {
        character.movement.Move(character.input.GetHorizontalInput(), character.statsHandler.GetStat("Speed"));
    }

    public void OnExit() { }

    public void Transition(StateMachine owner)
    {
        if (character.groundStatus.IsOnGround())
        {
            owner.SwitchState("Ground");
        }
        else if (character.wallStatus.IsOnWall())
        {
            owner.SwitchState("Wall");
        }
        else if (character.climbStatus.CanClimb() && (character.input.GetVerticalInput() > .5f || character.input.GetVerticalInput() < -.5f) && climbTimer.IsTimerUp())
        {
            owner.SwitchState("Climb");
        }
    }

    void TryJump()
    {
        bool _jump = character.input.GetJumpInput() && character.statsHandler.GetStat("Double Jump Amount") > 0;

        if (_jump)
        {
            character.physicsHandler.SetVelocity(new Vector2(character.physicsHandler.GetVelocity().x, 0));
            character.movement.Jump(character.statsHandler.GetStat("Jump Force"));
            character.statsHandler.SubtractStatValue("Double Jump Amount", 1);
        }
    }
}
