using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public interface ICharacterEventHandler
{
    void InvokeEvent(string name);
    void SubscribeToEvent(string name, UnityAction action);
    void UnsubscribeToEvent(string name, UnityAction action); 
}
