using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class CharacterEventHandler : CharacterClass, ICharacterEventHandler
{
    CharacterEvent[] events;

    public void SetData(CharacterEventData data) => events = data.events;

    public void InvokeEvent(string name) => events.First(x => x.name == name).action?.Invoke();

    public void SubscribeToEvent(string name, UnityAction action) => events.First(x => x.name == name).action.AddListener(action);
    public void UnsubscribeToEvent(string name, UnityAction action) => events.First(x => x.name == name).action.AddListener(action);
}
