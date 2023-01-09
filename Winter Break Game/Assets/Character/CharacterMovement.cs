using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public ICharacterInputHandler input;
    public ICharacterGroundStatusProvider groundStatus;
    public IChararacterWallStatusProvider wallStatus;
    public ICharacterDirectionHandler directionHandler;
    public ICharacterPhysicsHandler physicsHandler;
    public ICharacterEventHandler eventHandler;
    public ICharacterClimbStatusProvider climbStatus; 

    public StateMachine characterStateMachine;

    public void Awake()
    {
        input = GetComponent<ICharacterInputHandler>();
        groundStatus = GetComponent<ICharacterGroundStatusProvider>();
        wallStatus = GetComponent<IChararacterWallStatusProvider>();
        directionHandler = GetComponent<ICharacterDirectionHandler>();
        physicsHandler = GetComponent<ICharacterPhysicsHandler>();
        eventHandler = GetComponent<ICharacterEventHandler>();
        climbStatus = GetComponent<ICharacterClimbStatusProvider>();

        characterStateMachine = new StateMachine("CharacterGroundedState",
            new CharacterGroundedState(this),
            new CharacterAirborneState(this),
            new CharacterWallState(this),
            new CharacterClimbState(this));
    }

    public void Update()
    {
        characterStateMachine.InvokeCurrentState();
    }
}

