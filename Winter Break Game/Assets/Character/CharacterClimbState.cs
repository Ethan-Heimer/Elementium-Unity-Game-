using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClimbState : IState
{
    CharacterMovement controller;

    bool isClimbing;
    public CharacterClimbState(CharacterMovement _controller)
    {
        controller = _controller;
    }

    public void OnEnter() 
    {
        controller.physicsHandler.FreezeGravity(true);
        controller.physicsHandler.SetAccelerationStep(0);
    }

    public void WhileInState()
    {
        Vector2 moveVector = new Vector2(controller.input.GetHorizontalInput(), controller.input.GetVerticalInput());

        InvokeEvents(moveVector);

        controller.physicsHandler.Move(new Vector2(controller.input.GetHorizontalInput(), controller.input.GetVerticalInput()), controller.input.GetJumpInput() && controller.input.GetVerticalInput() > .1f);
    }

    public void OnExit()
    {
        controller.physicsHandler.FreezeGravity(false);
        isClimbing = false; 
    }

    public void Transition(StateMachine owner)
    {
        if (!controller.climbStatus.CanClimb() || controller.input.GetJumpInput())
        {
            owner.SwitchState("CharacterGroundedState"); 
        }
    }

    private void InvokeEvents(Vector2 moveVector)
    {
        if (moveVector == Vector2.zero && isClimbing)
        {
            isClimbing = false;
            controller.eventHandler.InvokeEvent("OnPlayerClimbIdle");
        }
        else if (moveVector != Vector2.zero && !isClimbing)
        {
            isClimbing = true;
            controller.eventHandler.InvokeEvent("OnPlayerClimbing");
        }
    }
}
