using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CharacterEventHandlerWithEventSystemAsset : ICharacterEventHandler
{
    public EventSystem eventSystem;

    public void InvokeEvent(string name) => eventSystem.InvokeEvent(name, new EventData());

    public void SubscribeToEvent(string name, UnityAction action) => eventSystem.SubscribeToEvent(name, (EventData data) => action.Invoke());
    public void UnsubscribeToEvent(string name, UnityAction action) => eventSystem.UnsubscribeToEvent(name, (EventData data) => action.Invoke());

    public object Clone() => MemberwiseClone();
    public void Constructer(Character charatcer) { }
}
