using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirborneState : CharacterClass, IState, IFixedState
{
    Timer climbTimer = new Timer(.5f);
    Timer backcheckCooldown = new Timer(.1f);
    Timer cyoteTime = new Timer(.25f);

    public void OnEnter() 
    {
        character.physicsHandler.SetMaxAcceleration(character.statsHandler.GetStat("Air Resistance"));

        character.statsHandler.ResetStatValue("Double Jump Amount");
        climbTimer.ResetTimer();
        backcheckCooldown.ResetTimer();
        cyoteTime.ResetTimer();
    }

    public void WhileInState()
    {
        TryJump();       
    }

    public void FixedWhileInState()
    {
        character.movement.Move(character.input.GetHorizontalInput(), character.statsHandler.GetStat("Speed"));

        if (character.wallStatus.IsBackTowordsWall() && backcheckCooldown.IsTimerUp()) character.physicsHandler.SetAcceleration(0);
    }

    public void OnExit() { }

    public void Transition(StateMachine owner)
    {
    
    }

    void TryJump()
    {
        bool _jump = character.input.GetJumpInput() && character.statsHandler.GetStat("Double Jump Amount") > 0;

        if (_jump)
        {
            character.physicsHandler.SetVelocity(new Vector2(character.physicsHandler.GetVelocity().x, 0));
            character.movement.Jump(character.statsHandler.GetStat("Jump Force"));

            if(cyoteTime.IsTimerUp())
                character.statsHandler.SubtractStatValue("Double Jump Amount", 1);
        }
    }
}
