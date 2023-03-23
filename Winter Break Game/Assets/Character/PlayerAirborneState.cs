using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirborneState : PlayerMovementState
{
    
    Timer climbTimer = new Timer(.5f);
    Timer backcheckCooldown = new Timer(.1f);

    float doubleJumpsLeft;

    public PlayerAirborneState(Character character, PlayerMovementHandler playerMovementHandler) : base(character, playerMovementHandler) { }
    
    public override void OnEnter() 
    {
        character.physicsHandler.SetMaxAcceleration(playerMovementHandler.InAirAirResistance);

        doubleJumpsLeft = playerMovementHandler.DoubleJumpAmount;

        climbTimer.ResetTimer();
        backcheckCooldown.ResetTimer();
    }

    public override void WhileInState()
    {
        bool _jump = character.input.GetJumpInput() && doubleJumpsLeft > 0;

        if (_jump)
        {
            character.physicsHandler.SetVelocity(new Vector2(character.physicsHandler.GetVelocity().x, 0));
            character.movement.Jump(playerMovementHandler.JumpHeight);
            doubleJumpsLeft--;
        }
    }

    public override void FixedWhileInState()
    {
        character.movement.Move(character.input.GetHorizontalInput(), playerMovementHandler.Speed);

        if (character.wallStatus.IsBackTowardsWall() && backcheckCooldown.IsTimerUp()) character.physicsHandler.SetAcceleration(0);
    }

    public override void OnExit() { }
}
