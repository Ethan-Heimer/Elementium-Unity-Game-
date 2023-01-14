using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class CharacterEventManager
{
    Character character;
    ICharacterEventHandler eventHandler;

    CharacterEventData data; 

    public CharacterEventManager(Character _character, CharacterEventData _data)
    {
        character = _character;
        data = _data; 
    }

    public void SetUp()
    {
        eventHandler = character.config.GetEventHandler();
        eventHandler.SetData(data);
    }

    public void InvokeEvent(string name)
    {
        eventHandler.InvokeEvent(name);
    }

    public void SubscribeToEvent(string name, UnityAction action)
    {
        eventHandler.SubscribeToEvent(name, action);
    }

    public void UnsubscribeFromEvent(string name, UnityAction action)
    {
        eventHandler.UnsubscribeToEvent(name, action); 
    }
}

[System.Serializable]
public class CharacterEventData
{
    public CharacterEvent[] events; 

}

[System.Serializable]
    public struct CharacterEvent
{
    public string name;
    public UnityEvent action;
}

