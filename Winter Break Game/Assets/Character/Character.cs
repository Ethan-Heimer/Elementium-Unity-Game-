using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Character : MonoBehaviour
{
    public static Character GetPlayer() => _player;
    private static Character _player;

    [SerializeField] CharacterConfig config;

    public CharacterGroundStatusInterfacer groundStatus;
    public CharacterWallStatusInterfacer wallStatus;
    public CharacterClimbStatusInterfacer climbStatus;
    public CharacterInputInterfacer input;
    public CharacterDirectionHandlerInterfacer directionHandler;
    public CharacterPhysicsHandlerInterfacer physicsHandler;

    CharacterDamageCheckerInterfacer damageChecker;
    CharacterDamageHandlerInterfacer damageHandler;

    public CharacterMovement movement;
    public CharacterDamageManager damageManager;
    public CharacterEventManager eventManager;

    CharacterMovementBehaviorInterfacer movementBehavior;
    CharacterActionBehaviorInterfacer actionHandler;

    public void Start()
    {
        if (config.IsPlayer) _player = this;

        groundStatus = new CharacterGroundStatusInterfacer(this, config);
        wallStatus = new CharacterWallStatusInterfacer(this, config);
        climbStatus = new CharacterClimbStatusInterfacer(this, config);
        input = new CharacterInputInterfacer(this, config);
        directionHandler = new CharacterDirectionHandlerInterfacer(this, config);
        physicsHandler = new CharacterPhysicsHandlerInterfacer(this, config);

        damageChecker = new CharacterDamageCheckerInterfacer(this, config);
        damageHandler = new CharacterDamageHandlerInterfacer(this, config);

        movementBehavior = new CharacterMovementBehaviorInterfacer(this, config);
        actionHandler = new CharacterActionBehaviorInterfacer(this, config);

        movement = new CharacterMovement(this);
        damageManager = new CharacterDamageManager(this, damageChecker, damageHandler);
        eventManager.Init(this);

        movementBehavior.Start();
    }

    public void Update()
    {
        if (pauseExecution) return;

        groundStatus.Tick();
        movementBehavior.Update();

        if (input.GetActionInput())
            actionHandler.OnAction();

    }

    public void FixedUpdate()
    {
        if (pauseExecution) return;

        wallStatus.Tick();
        climbStatus.Tick();
        movementBehavior.FixedUpdate();
    }


    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;
    Collider2D collider2D;

    bool pauseExecution;
    public void PauseExecution(bool pause) => pauseExecution = pause;

    public void DisableCharacter(bool active)
    {
        spriteRenderer.enabled = !active;
        rigidbody2D.isKinematic = active;
        //physicsHandler.FreezeGravity(active);
        collider2D.isTrigger = active;

        PauseExecution(active);

        foreach (Transform o in transform)
        {
            if (!o.CompareTag("Stay On Disable"))
            {
                o.gameObject.SetActive(!active);
            }
        }
    }

    public void OnDrawGizmos()
    {
        try
        {
            wallStatus.DrawGizmos();
            groundStatus.DrawGizmos();
        }
        catch { }

    }
}


