using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterConfig config;

    public ICharacterInputHandler input;
    public ICharacterGroundStatusProvider groundStatus;
    public IChararacterWallStatusProvider wallStatus;
    public ICharacterDirectionHandler directionHandler;
    public ICharacterPhysicsHandler physicsHandler;
    public ICharacterClimbStatusProvider climbStatus;

    public ICharacterDamageChecker damageChecker;
    public ICharacterDamageHandler damageHandler;

    public ICharacterStatsHandler statsHandler;

    ICharacterActionHandler actionHandler;
    ICharacterMovementHandler movementHandler; 

    public CharacterMovement movement;
    public CharacterDamageManager damageManager;
    public CharacterEventManager eventManager;

    bool pauseExecution; 
    public void PauseExecution(bool pause) => pauseExecution = pause; 

    public void Awake()
    {
        input = config.GetInputHandler();
        groundStatus = config.GetGroundHandler();
        wallStatus = config.GetWallProvider();
        directionHandler = config.GetDirectionHandler();
        physicsHandler = config.GetPhysicsHandler();
        climbStatus = config.GetClimbHandler();

        damageChecker = config.GetDamageChecker();
        damageHandler = config.GetDamageHandler();

        statsHandler = config.GetStatsHandler();
        actionHandler = config.GetActionHandler();

        movementHandler = config.GetMovementHandler();

        input.Constructer(this);
        groundStatus.Constructer(this);
        wallStatus.Constructer(this);
        directionHandler.Constructer(this);
        physicsHandler.Constructer(this);
        climbStatus.Constructer(this);

        damageChecker.Constructer(this);
        damageHandler.Constructer(this);

        actionHandler.Constructer(this);
        movementHandler.Constructer(this);

        movement = new CharacterMovement(this);
        damageManager = new CharacterDamageManager(this);

        actionHandler.Start();
        movementHandler.Start();
    }

    public void Update()
    {
        if (pauseExecution) return;

        damageManager.Tick();
        actionHandler.Update();
        movementHandler.Update();
    }

    public void FixedUpdate()
    {
        if (pauseExecution) return;
        movementHandler.FixedUpdate();
    }
}
