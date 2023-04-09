using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

public class Character : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    public static Character GetPlayer() => _player;
    private static Character _player;

    public CharacterEventManager eventManager;
    public CharacterConfigManager configManager;

    public CharacterEnviormentStatusProvidersInterfacer enviormentStatuses; 
    public CharacterInputInterfacer input;
    public CharacterDirectionHandlerInterfacer directionHandler;
    public CharacterPhysicsHandlerInterfacer physicsHandler;

    CharacterDamageCheckerInterfacer damageChecker;
    CharacterDamageHandlerInterfacer damageHandler;

    CharacterMovementBehaviorInterfacer movementBehavior;
    CharacterActionBehaviorInterfacer actionHandler;

    public CharacterMovement movement;
    public CharacterDamageManager damageManager;
  

    public void Awake()
    {
        if (isPlayer) _player = this;
       
        input = new CharacterInputInterfacer(this, configManager);
        directionHandler = new CharacterDirectionHandlerInterfacer(this, configManager);
        physicsHandler = new CharacterPhysicsHandlerInterfacer(this, configManager);

        damageChecker = new CharacterDamageCheckerInterfacer(this, configManager);
        damageHandler = new CharacterDamageHandlerInterfacer(this, configManager);

        movementBehavior = new CharacterMovementBehaviorInterfacer(this, configManager);
        actionHandler = new CharacterActionBehaviorInterfacer(this, configManager);

        movement = new CharacterMovement(this);
        damageManager = new CharacterDamageManager(this, damageChecker, damageHandler);
        enviormentStatuses = new CharacterEnviormentStatusProvidersInterfacer(this, configManager);

        eventManager.GetType().GetMethod("Init", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(eventManager, new object[] { this });
        
        enviormentStatuses.CheckStatuses();
        

    }

    public void Update()
    {
        if (pauseExecution) return;

        enviormentStatuses.CheckStatuses();
        movementBehavior.OnUpdate();

        if (input.GetActionInput())
            actionHandler.OnAction();

    }

    public void FixedUpdate()
    {
        if (pauseExecution) return;

        movementBehavior.OnFixedUpdate();
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
            enviormentStatuses.DrawGizmos(); 
        }
        catch { }

    }
}
