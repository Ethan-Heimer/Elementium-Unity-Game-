using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : CharacterClass, ICharacterMovementHandler
{
    public CharacterStateMachiene characterStateMachine;

    public void Start()
    {
        characterStateMachine = new CharacterStateMachiene(
            new PlayerGroundedState(),
            new PlayerAirborneState(),
            new PlayerWallState(),
            new PlayerClimbState(), character);
    }

    public void Update()
    {
        characterStateMachine.InvokeCurrentState();
    }

    public void FixedUpdate()
    {
        characterStateMachine.InvokeFixedState();
    }
}
