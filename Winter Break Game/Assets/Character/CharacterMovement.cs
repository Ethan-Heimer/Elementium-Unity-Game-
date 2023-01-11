using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement
{
    public CharacterConfig config;
    public Character character; 

    public CharacterMovement(Character _character)
    {
        character = _character;
        config = character.config; 
    }

    public ICharacterInputHandler input;
    public ICharacterGroundStatusProvider groundStatus;
    public IChararacterWallStatusProvider wallStatus;
    public ICharacterDirectionHandler directionHandler;
    public ICharacterPhysicsHandler physicsHandler;
    public ICharacterEventHandler eventHandler;
    public ICharacterClimbStatusProvider climbStatus; 

    public StateMachine characterStateMachine;

    public void SetUp()
    {
        input = config.GetInputHandler();
        groundStatus = config.GetGroundHandler();
        wallStatus = config.GetWallProvider();
        directionHandler = config.GetDirectionHandler();
        physicsHandler = config.GetPhysicsHandler();
        eventHandler = config.GetEventHandler();
        climbStatus = config.GetClimbHandler();

        input.Constructer(character);
        groundStatus.Constructer(character);
        wallStatus.Constructer(character);
        directionHandler.Constructer(character);
        physicsHandler.Constructer(character);
        eventHandler.Constructer(character);
        climbStatus.Constructer(character);

        characterStateMachine = new StateMachine("CharacterGroundedState",
            new CharacterGroundedState(this),
            new CharacterAirborneState(this),
            new CharacterWallState(this),
            new CharacterClimbState(this));
    }

    public void Tick()
    {
        characterStateMachine.InvokeCurrentState();
    }
}

