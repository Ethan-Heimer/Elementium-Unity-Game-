using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;
using System.Linq.Expressions;

public abstract class CharacterComponentInterfacer<T> where T : CharacterComponent
{
    protected Character character;
    CharacterConfigManager configManager; 

    //CharacterComponentFieldHandler<T> fieldHandler;

    public CharacterComponentInterfacer(Character _character, CharacterConfigManager _characterConfig)
    {
        character = _character;
        configManager = _characterConfig;
    }
   
    public CharacterEvent[] GetEvents() => configManager.GetCharacterComponent<T>().GetEvents();

    public T Component
    {
        get
        {
            return configManager.GetCharacterComponent<T>();
        }
    }
}

/*
internal class CharacterComponentFieldHandler<T> where T : CharacterComponent
{
    Dictionary<string, float> values;
    getCompoent getCompoent;
    public CharacterComponentFieldHandler(getCompoent _getCompoentMethod)
    {
        getCompoent = _getCompoentMethod;

    }

    void InitFields() => GetStats((T)getCompoent());

    void GetStats(T component)
    {
        values = new Dictionary<string, float>();
        FieldInfo[] fields = typeof(T).GetFields().Where(x => x.FieldType == typeof(float)).ToArray();

        foreach (FieldInfo o in fields)
        {
            values.Add(o.Name, (float)o.GetValue(component));
        }
    }

    public float GetStat(string name) => values[name];
    public void SetStat(string name, float value) => values[name] = value;
}

*/

