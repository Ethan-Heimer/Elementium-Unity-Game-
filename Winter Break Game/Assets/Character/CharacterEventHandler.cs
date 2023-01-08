using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;


public class CharacterEventHandler : MonoBehaviour, ICharacterEventHandler
{
    [System.Serializable]
    struct CharacterEvent
    {
        public string name;
        public UnityEvent action; 
    }

    [SerializeField] CharacterEvent[] events; 

    public void InvokeEvent(string name) => events.First(x => x.name == name).action?.Invoke();

    public void SubscribeToEvent(string name, UnityAction action) => events.First(x => x.name == name).action.AddListener(action);
    public void UnsubscribeToEvent(string name, UnityAction action) => events.First(x => x.name == name).action.AddListener(action); 
}
