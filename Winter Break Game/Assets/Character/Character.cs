using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character GetPlayer() => _player;
    private static Character _player;

    public CharacterConfig config;

    public ICharacterInputHandler input;
    public GroundStatusProvider groundStatus;
    public WallStatusProvider wallStatus;
    public ICharacterDirectionHandler directionHandler;
    public ICharacterPhysicsHandler physicsHandler;
    public ClimbStatusProvider climbStatus;

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

        movement = new CharacterMovement(this);
        damageManager = new CharacterDamageManager(this);

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

        eventManager.Constructer(this);

        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();

        if (config.IsPlayer) _player = this; 
    }

    public void Start()
    {
        actionHandler.Start();
        movementHandler.Start();
    }

    public void Update()
    {
        if (pauseExecution) return;

        damageManager.Tick();
        movementHandler.Update();

        if (input.GetActionInput())
            actionHandler.OnAction();

        groundStatus.Tick();
    }

    public void FixedUpdate()
    {
        //worst perforance
        if (pauseExecution) return;
        movementHandler.FixedUpdate();

        wallStatus.Tick();
        climbStatus.Tick();
    }


    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;
    Collider2D collider2D; 

    public void DisableCharacter(bool active)
    {
        spriteRenderer.enabled = !active;
        rigidbody2D.isKinematic = active;
        physicsHandler.FreezeGravity(active);
        collider2D.isTrigger = active;

        PauseExecution(active);

        foreach (Transform o in transform)
        {
            if(!o.CompareTag("Stay On Disable"))
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
