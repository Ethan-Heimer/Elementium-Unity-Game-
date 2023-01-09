using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWallState : IState
{
    CharacterMovement controller;
    
    public CharacterWallState(CharacterMovement _controller)
    {
        controller = _controller;
    }

    public void OnEnter()
    {
        controller.physicsHandler.SetAccelerationStepCap(1);
        controller.eventHandler.InvokeEvent("OnWall");
    }

    public void WhileInState()
    {
        int dirFacing = controller.directionHandler.GetCurrentDirection();
        float inputDir = controller.input.GetHorizontalInput();

        if(inputDir == dirFacing && controller.physicsHandler.GetVelocity().y < 0)
        { 
           controller.physicsHandler.SetVelocity(new Vector2(controller.physicsHandler.GetSpeed() * dirFacing, -controller.physicsHandler.GetSpeed()/1.5f));
        }
        else if(inputDir == -dirFacing)
        {
            controller.directionHandler.FlipCharacter(-dirFacing);
            controller.physicsHandler.SetAccelerationStep(0);
        }

        if (controller.input.GetJumpInput())
        {
            controller.physicsHandler.SetAccelerationStep(-dirFacing);
            controller.eventHandler.InvokeEvent("OnJump");
            controller.physicsHandler.Move(-dirFacing, true);
        }
    }

    public void OnExit() => controller.eventHandler.InvokeEvent("OffWall");
    public void Transition(StateMachine owner)
    {
        if (controller.groundStatus.IsOnGround())
        {
            owner.SwitchState("CharacterGroundedState");
        }
        else if(!controller.groundStatus.IsOnGround() && !controller.wallStatus.IsOnWall())
        {
            owner.SwitchState("CharacterAirborneState");
        }
    }
}
