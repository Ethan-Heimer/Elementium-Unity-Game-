using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAirborneState : IState
{
    CharacterMovement controller;
    int jumpsLeft;

    bool _jump;
    bool jump
    {
        get
        {
            return _jump; 
        }

        set
        {
            _jump = value && jumpsLeft > 0;

            if (_jump)
            {
                controller.physicsHandler.SetVelocity(new Vector2(controller.physicsHandler.GetVelocity().x, 0));
                jumpsLeft--;
                controller.eventHandler.InvokeEvent("OnJump");
            }
        }
    }

    Timer climbTimer = new Timer(.3f); 

    public CharacterAirborneState(CharacterMovement _controller)
    {
        controller = _controller;
    }

    public void OnEnter() 
    {
        controller.physicsHandler.SetAccelerationStepCap(.65f);
        controller.eventHandler.InvokeEvent("InAir");

        jumpsLeft = 1;
        climbTimer.ResetTimer();

    }

    public void WhileInState()
    {
        jump = controller.input.GetJumpInput(); 
        controller.physicsHandler.Move(controller.input.GetHorizontalInput(), jump);
    }

    public void OnExit() { }

    public void Transition(StateMachine owner)
    {
        if (controller.groundStatus.IsOnGround())
        {
            owner.SwitchState("CharacterGroundedState");
        }
        else if (controller.wallStatus.IsOnWall())
        {
            owner.SwitchState("CharacterWallState");
        }
        else if (controller.climbStatus.CanClimb() && (controller.input.GetVerticalInput() > .5f || controller.input.GetVerticalInput() < -.5f) && climbTimer.IsTimerUp())
        {
            owner.SwitchState("CharacterClimbState");
        }
    }
}
