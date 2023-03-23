using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Linq;
using UnityEngine.Events;

[CreateAssetMenu]
public class CharacterConfig : ScriptableObject
{
    public bool IsPlayer;

    [RepresentType(typeof(CharacterInputHandler))] public event Action OnInputHandlerChanged;
    [RepresentType(typeof(GroundStatusProvider))] public event Action OnGroundStatusProviderChanged;
    [RepresentType(typeof(WallStatusProvider))] public event Action OnWallStatusProviderChanged;
    [RepresentType(typeof(CharacterDirectionHandler))] public event Action OnDirectionHandlerChanged;
    [RepresentType(typeof(CharacterPhysicsHandler))] public event Action OnPhysicsHandlerChanged;
    [RepresentType(typeof(ClimbStatusProvider))] public event Action OnClimbStatusProviderChanged;
    [RepresentType(typeof(CharacterMovementHandler))] public event Action OnMovementHandlerChanged;
    [RepresentType(typeof(CharacterDamageChecker))] public event Action OnDamageCheckerChanged;
    [RepresentType(typeof(CharacterDamageHandler))] public event Action OnDamageHandlerChanged;
    [RepresentType(typeof(CharacterActionHandler))] public event Action OnActionHandlerChanged;

    [SerializeReference] CharacterInputHandler input;
    [SerializeReference] GroundStatusProvider groundStatus;
    [SerializeReference] WallStatusProvider wallStatus;
    [SerializeField] CharacterDirectionHandler directionHandler;
    [SerializeReference] CharacterPhysicsHandler physicsHandler;
    [SerializeReference] ClimbStatusProvider climbStatus;
    [SerializeReference] CharacterMovementHandler movementHandler; 

    [SerializeReference] CharacterDamageChecker damageChecker;
    [SerializeReference] CharacterDamageHandler damageHandler;

    [SerializeReference] CharacterActionHandler actionHandler;

    CharacterInputHandler _input;
    GroundStatusProvider _groundStatus;
    WallStatusProvider _wallStatus;
    CharacterDirectionHandler _directionHandler;
    CharacterPhysicsHandler _physicsHandler;
    ClimbStatusProvider _climbStatus;
    CharacterMovementHandler _movementHandler;

    CharacterDamageChecker _damageChecker;
    CharacterDamageHandler _damageHandler;

    CharacterActionHandler _actionHandler;

    public CharacterInputHandler GetInputHandler()
    {
        if (_input != input)
        {
            _input = input;
            OnInputHandlerChanged?.Invoke();
        }
        return input;
    }
    public GroundStatusProvider GetGroundStatusProvider()
    {
        if (_groundStatus != groundStatus)
        {
            _groundStatus = groundStatus;
            OnGroundStatusProviderChanged?.Invoke();
        }
        return groundStatus;
    }
    public WallStatusProvider GetWallStatusProvider()
    {
        if (_wallStatus != wallStatus)
        {
            _wallStatus = wallStatus;
            OnWallStatusProviderChanged?.Invoke();
        }
        return wallStatus;
    }
    public CharacterDirectionHandler GetDirectionHandler()
    {
        if (_directionHandler != directionHandler)
        {
            _directionHandler = directionHandler;
            OnDirectionHandlerChanged?.Invoke();
        }
        return directionHandler;
    }
    public CharacterPhysicsHandler GetPhysicsHandler()
    {
        if (_physicsHandler != physicsHandler)
        {
            _physicsHandler = physicsHandler;
            OnPhysicsHandlerChanged?.Invoke();
        }
        return physicsHandler;
    }
    public ClimbStatusProvider GetClimbStatusProvider()
    {
        if (_climbStatus != climbStatus)
        {
            _climbStatus = climbStatus;
            OnClimbStatusProviderChanged?.Invoke();
        }
        return climbStatus;
    }
    public CharacterMovementHandler GetMovementHandler()
    {
        if (_movementHandler != movementHandler)
        {
            _movementHandler = movementHandler;
            OnMovementHandlerChanged?.Invoke();
        }
        return movementHandler;
    }
    public CharacterDamageChecker GetDamageChecker()
    {
        if (_damageChecker != damageChecker)
        {
            _damageChecker = damageChecker;
            OnDamageCheckerChanged?.Invoke();
        }
        return damageChecker;
    }
    public CharacterDamageHandler GetDamageHandler()
    {
        if (_damageHandler != damageHandler)
        {
            _damageHandler = damageHandler;
            OnDamageHandlerChanged?.Invoke();
        }
        return damageHandler;
    }
    public CharacterActionHandler GetActionHandler()
    {

        if (_actionHandler != actionHandler)
        {
            _actionHandler = actionHandler;
            OnActionHandlerChanged?.Invoke();
        }
        return actionHandler;
    }
}
