using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class CharacterEventHandlerWithEventSystemAsset : MonoBehaviour, ICharacterEventHandler
{
    [SerializeField] EventSystem eventSystem;

    public void InvokeEvent(string name) => eventSystem.InvokeEvent(name, new EventData());

    public void SubscribeToEvent(string name, UnityAction action) => eventSystem.SubscribeToEvent(name, (EventData data) => action.Invoke());
    public void UnsubscribeToEvent(string name, UnityAction action) => eventSystem.UnsubscribeToEvent(name, (EventData data) => action.Invoke()); 
}
