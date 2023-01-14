using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public interface ICharacterEventHandler : ICharacterInterface
{
    void SetData(CharacterEventData data); 
    void InvokeEvent(string name);
    void SubscribeToEvent(string name, UnityAction action);
    void UnsubscribeToEvent(string name, UnityAction action); 
}
