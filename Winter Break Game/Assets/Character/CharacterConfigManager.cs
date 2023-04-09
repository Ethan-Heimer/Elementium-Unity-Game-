using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

[System.Serializable]
public class CharacterConfigManager
{
    [SerializeField] CharacterConfig config;

    List<CharacterComponent> components = new List<CharacterComponent>();
    Character character;

    CharacterInputHandler _input;
    CharacterEnviormentStatusHolder _statusHolder;
    CharacterDirectionHandler _directionHandler;
    CharacterPhysicsHandler _physicsHandler;
    CharacterMovementHandler _movementHandler;
    CharacterDamageChecker _damageChecker;
    CharacterDamageHandler _damageHandler;
    CharacterActionHandler _actionHandler;

    public void Init(Character _character)
    {
        character = _character;

        _input = config.input;
        _statusHolder = config.statusHolder;
        _directionHandler = config.directionHandler;
        _physicsHandler = config.physicsHandler;
        _movementHandler = config.movementHandler;
        _damageChecker = config.damageChecker;
        _actionHandler = config.actionHandler;
    }

    public T GetCharacterComponent<T>() where T : CharacterComponent
    {
        foreach(CharacterComponent c in components)
        {
            if (c.GetType() == typeof(T))
                return (T)c; 
        }

        T component = (T)config.GetType().GetFields().First(x => x.FieldType == typeof(T)).GetValue(config);

        if (component is not null)
        {
            components.Add((CharacterComponent)component);
            component.OnStart(character);
        }

        return component;
    }

    public void SetCharacterComponent<T>(T component) where T : CharacterComponent => this.GetType().GetFields().First(x => x.FieldType == typeof(T)).SetValue(this, component);

    public CharacterComponent[] GetAllComponents()
    {
        List<CharacterComponent> components = new List<CharacterComponent>();
        FieldInfo[] fields = config.GetType().GetFields();

        foreach(FieldInfo o in fields)
        {
            components.Add((CharacterComponent)o.GetValue(config));
        }

        return components.ToArray();
    }
   
}
