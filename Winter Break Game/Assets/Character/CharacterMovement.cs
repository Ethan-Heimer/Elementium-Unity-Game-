using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement
{
    public CharacterConfig config;
    Character character;

    public ICharacterInputHandler input;
    public ICharacterGroundStatusProvider groundStatus;
    public IChararacterWallStatusProvider wallStatus;
    public ICharacterDirectionHandler directionHandler;
    public ICharacterPhysicsHandler physicsHandler;
    public ICharacterClimbStatusProvider climbStatus;

    public CharacterStateMachiene characterStateMachine;


    public CharacterMovement(Character _character)
    {
        character = _character;
        config = character.config;
    }

   
    public void SetUp()
    {
        input = config.GetInputHandler();
        groundStatus = config.GetGroundHandler();
        wallStatus = config.GetWallProvider();
        directionHandler = config.GetDirectionHandler();
        physicsHandler = config.GetPhysicsHandler();
        climbStatus = config.GetClimbHandler();

        input.Constructer(character);
        groundStatus.Constructer(character);
        wallStatus.Constructer(character);
        directionHandler.Constructer(character);
        physicsHandler.Constructer(character);
        climbStatus.Constructer(character);

        characterStateMachine = new CharacterStateMachiene(
            config.GetGroundState(),
            config.GetAirState(),
            config.GetWallState(),
            config.GetClimbState(), character);
    }

    public void Tick()
    {
        characterStateMachine.InvokeCurrentState();
    }

    public void FixedTick()
    {
        characterStateMachine.InvokeFixedState();
    }
}

