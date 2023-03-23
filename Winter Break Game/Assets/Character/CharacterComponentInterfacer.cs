using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

public abstract class CharacterComponentInterfacer<T> where T : CharacterComponent
{
    protected Character character;
    protected CharacterComponentFieldHandler<T> fieldHandler;

    CharacterConfig characterConfig;

    delegate T getCompoent();
    getCompoent _getComponent;

    public CharacterComponentInterfacer(Character _character, CharacterConfig _characterConfig)
    {
        character = _character;
        characterConfig = _characterConfig;

        //find correct compoenet
        MethodInfo getComponentMethod = typeof(CharacterConfig).GetMethods().First(x => x.ReturnType == typeof(T));
        _getComponent = () => (T)getComponentMethod.Invoke(characterConfig, null);

        NewFieldHandler();
        RunComponentStart();
        fieldHandler.FillStats();

        //subscribe to events -- set things up when component changed
        EventInfo onChangedEvent = characterConfig.GetType().GetEvents().First(x => (Type)x.GetCustomAttribute(typeof(RepresentTypeAttribute)).GetType().GetField("type").GetValue(x.GetCustomAttribute(typeof(RepresentTypeAttribute))) == typeof(T));
  
        MethodInfo makeNewFieldHandler = this.GetType().BaseType.GetMethod("NewFieldHandler", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
        Delegate newFieldDelegate = Delegate.CreateDelegate(onChangedEvent.EventHandlerType, this, makeNewFieldHandler);

        MethodInfo fillStats = fieldHandler.GetType().GetMethod("FillStats");
        Delegate fillStatsHandler = Delegate.CreateDelegate(onChangedEvent.EventHandlerType, fieldHandler, fillStats);

        MethodInfo start = this.GetType().BaseType.GetMethod("RunComponentStart", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy) ;
        Delegate startHandler = Delegate.CreateDelegate(onChangedEvent.EventHandlerType, this, start);

        onChangedEvent.AddEventHandler(characterConfig, newFieldDelegate);
        onChangedEvent.AddEventHandler(characterConfig, fillStatsHandler);
        onChangedEvent.AddEventHandler(characterConfig, startHandler);
    }

    public void GetStat(string name) => fieldHandler.GetStat(name);
    public void SetStat(string name) => fieldHandler.GetStat(name);

    protected T GetCharacterComponent() => _getComponent.Invoke();
    void RunComponentStart() => GetCharacterComponent().OnStart(character);
    void NewFieldHandler() => fieldHandler = new CharacterComponentFieldHandler<T>(GetCharacterComponent());
}

public class CharacterComponentFieldHandler<T> where T : CharacterComponent
{
    Dictionary<string, float> values = new Dictionary<string, float>();
    T component;

    public CharacterComponentFieldHandler(T _component)
    {
        component = _component;
        FillStats();
    }

    public void FillStats()
    {
        FieldInfo[] fields = typeof(T).GetFields().Where(x => x.FieldType == typeof(float)).ToArray();

        foreach (FieldInfo o in fields)
        {
            values.Add(o.Name, (float)o.GetValue(component));
        }
    }

    public float GetStat(string name) => values[name];
    public void SetStat(string name, float value) => values[name] = value;
}
