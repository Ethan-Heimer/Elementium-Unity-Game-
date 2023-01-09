using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class CharacterGroundedState : IState
{
    CharacterMovement controller;

    bool _IsWalking;
    bool IsWalking
    {
        get
        {
            return _IsWalking;
        }

        set
        {
            if (value && !_IsWalking)
            {
                controller.eventHandler.InvokeEvent("OnStartWalk");
            }
            else if (!value && _IsWalking)
            {
                controller.eventHandler.InvokeEvent("OnEndWalk");
            }

            _IsWalking = value;
        }
    }

    bool _jump; 
    bool jump
    {
        get
        {
            return _jump;
        }

        set
        {
            if(value) controller.eventHandler.InvokeEvent("OnJump");
            _jump = value; 
        }
    }

    public CharacterGroundedState(CharacterMovement _controller)
    {
        controller = _controller;
    }

    public void OnEnter()
    {
        controller.physicsHandler.SetAccelerationStepCap(1);
        controller.eventHandler.InvokeEvent("OnGround");
    }
    public void WhileInState()
    {
        float xInput = controller.input.GetHorizontalInput();
        IsWalking = xInput != 0;
        jump = controller.input.GetJumpInput(); 
        controller.physicsHandler.Move(xInput, jump);
    }
    public void OnExit()
    {
        IsWalking = false;
        controller.eventHandler.InvokeEvent("OnEndWalk");
    }
    public void Transition(StateMachine owner)
    {
        if (!controller.groundStatus.IsOnGround())
        {
            if (controller.wallStatus.IsOnWall())
            {
                owner.SwitchState("CharacterWallState");
            }

            else
            {
                owner.SwitchState("CharacterAirborneState");
            }
        }
        else if (controller.climbStatus.CanClimb() && (controller.input.GetVerticalInput() > .5f || controller.input.GetVerticalInput() < -.5f))
        {
            owner.SwitchState("CharacterClimbState"); 
        }
    }
}