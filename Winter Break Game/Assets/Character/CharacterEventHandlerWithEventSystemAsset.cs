using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CharacterEventHandlerWithEventSystemAsset : CharacterClass, ICharacterEventHandler
{
    //public EventSystem eventSystem;

    /*
    public void SetData(CharacterEventData data)
    {
        foreach(CharacterEvent o in data.events)
        {
            eventSystem.SubscribeToEvent(o.name, (EventData) => o.action.Invoke());
        }
    }
    */
    public void InvokeEvent(string name) { } //=> eventSystem.InvokeEvent(name, new EventData());

    public void SubscribeToEvent(string name, UnityAction action) { } //=> eventSystem.SubscribeToEvent(name, (EventData data) => action.Invoke());
    public void UnsubscribeToEvent(string name, UnityAction action) { }//=> eventSystem.UnsubscribeToEvent(name, (EventData data) => action.Invoke());
}
