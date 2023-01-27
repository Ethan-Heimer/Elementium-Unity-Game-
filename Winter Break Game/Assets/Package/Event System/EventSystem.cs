using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System;
using System.Reflection.Emit;
using System.Threading.Tasks;

[CreateAssetMenu]
public class EventSystem : ScriptableObject
{
    [SerializeField] Event[] events;
    [SerializeField] FlagEvent[] flagEvents; 

    public void SubscribeToEvent(string name, UnityAction<EventData> action)
    {
        try
        {
            events.First(evnt => evnt.Name == name)._event.AddListener(action);
        }
        catch(InvalidOperationException)
        {
            Debug.LogError(name + " is not an event"); 
        }
       
    }

    public void UnsubscribeToEvent(string name, UnityAction<EventData> action)
    {
        try
        {
            events.First(evnt => evnt.Name == name)._event.RemoveListener(action);
        }
        catch(InvalidOperationException)
        {
            Debug.LogError(name + " is not an event");
        }
    }

    public void InvokeEvent(string name, EventData data)
    {
        try
        {
            events.First(x => x.Name == name)._event.Invoke(data);
        }
        catch (InvalidOperationException)
        {
            Debug.LogError(name + " is not an event");
        }
    }

    //Flag Events
    public bool IsEventFlagged(string name) => flagEvents.First(e => e.name == name).flagged; 
    public void FlagEvent(string name, EventData data) => flagEvents.First(e => e.name == name).Flag(data);
    public void UnflagEvent(string name) => flagEvents.First(e => e.name == name).Unflag();

    public void OnEventFlagged(string name, UnityAction<EventData> action) => flagEvents.First(e => e.name == name).onEventFlagged.AddListener(action);
    public void RemoveOnEventFlagged(string name, UnityAction<EventData> action) => flagEvents.First(e => e.name == name).onEventFlagged.RemoveListener(action);

    public void WhileEventFlagged(string name, UnityAction<EventData> action) => flagEvents.First(e => e.name == name).whileFlagged.AddListener(action);
    public void RemoveWhileEventFlagged(string name, UnityAction<EventData> action) => flagEvents.First(e => e.name == name).whileFlagged.RemoveListener(action);

    public void OnEventUnflagged(string name, UnityAction<EventData> action) => flagEvents.First(e => e.name == name).onEventUnflagged.AddListener(action);
    public void RemoveOnEventUnflagged(string name, UnityAction<EventData> action) => flagEvents.First(e => e.name == name).onEventUnflagged.RemoveListener(action);

    public string[] GetAllEventNames()
    {
        string[] names = new string[events.Length]; 

        for(int i = 0; i < events.Length; i++)
        {
            names[i] = events[i].Name; 
        }

        return names; 
    }
}

[System.Serializable]
public struct Event
{
    public string Name; 
    public UnityEvent<EventData> _event; 
}

[System.Serializable]
public class FlagEvent
{
    public string name;

    public bool flagged;
     
    public UnityEvent<EventData> onEventFlagged;
    public UnityEvent<EventData> whileFlagged;
    public UnityEvent<EventData> onEventUnflagged;

    async void RunFlaggedEvents(EventData data)
    {
        onEventFlagged.Invoke(data);

        while (flagged)
        {
            whileFlagged.Invoke(data);
            await Task.Yield();
        }

        onEventUnflagged.Invoke(data);
    }

    public void Flag(EventData _data)
    {
        if (flagged) return; 

        flagged = true;
        RunFlaggedEvents(_data);


        //Debug.Log(name + " is Flagged");
    }

    public void Unflag()
    {
        if (!flagged) return; 

        flagged = false;

        //Debug.Log(name + " is Unflagged");
    }

}

public class EventData
{
    EventInfo[] data; 
    public EventData(params EventInfo[] data) => this.data = data;

    public object GetData(string name)
    {
        //get eventInfo 
        try
        {
            EventInfo info = data.First(d => d.infoName == name);
            return info.info;
        }
        catch (InvalidOperationException)
        {
            //Debug.LogError(name + "Is not a Data Name"); 
        }

        return null; 
        
    }
}

public class EventInfo
{
    public string infoName; 
    public object info; 

    public EventInfo(string name, object data)
    {
        infoName = name;
        info = data; 
    }
}

