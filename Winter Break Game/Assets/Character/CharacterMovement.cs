using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeReference] public ICharacterInputHandler input;
    public ICharacterGroundStatusProvider groundStatus;
    public IChararacterWallStatusProvider wallStatus;
    public ICharacterDirectionHandler directionHandler;
    public ICharacterPhysicsHandler physicsHandler;
    public ICharacterEventHandler eventHandler; 

    public StateMachine characterStateMachine;

    public void Awake()
    {
        input = GetComponent<ICharacterInputHandler>();
        groundStatus = GetComponent<ICharacterGroundStatusProvider>();
        wallStatus = GetComponent<IChararacterWallStatusProvider>();
        directionHandler = GetComponent<ICharacterDirectionHandler>();
        physicsHandler = GetComponent<ICharacterPhysicsHandler>();
        eventHandler = GetComponent<ICharacterEventHandler>();

        characterStateMachine = new StateMachine("CharacterGroundedState",
            new CharacterGroundedState(this),
            new CharacterAirborneState(this),
            new CharacterWallState(this));
    }

    public void Update()
    {
        characterStateMachine.InvokeCurrentState();
    }
}

