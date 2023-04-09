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
    [SerializeReference] public CharacterInputHandler input;
    [SerializeField] public CharacterDirectionHandler directionHandler;
    [SerializeReference] public CharacterPhysicsHandler physicsHandler;
    [SerializeReference] public CharacterMovementHandler movementHandler;
    [SerializeReference] public CharacterDamageChecker damageChecker;
    [SerializeReference] public CharacterDamageHandler damageHandler;
    [SerializeReference] public CharacterActionHandler actionHandler;
    [SerializeField] public CharacterEnviormentStatusHolder statusHolder;
}
