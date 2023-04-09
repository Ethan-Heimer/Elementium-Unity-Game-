using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CharacterEventManager
{
    [SerializeField] EventManagerInspectorHandler inspectorHandler = new EventManagerInspectorHandler();

    Character character;
    Dictionary<string, EventAction> events = new Dictionary<string, EventAction>();

    void Init()
    {
        foreach(UEvent o in inspectorHandler.Events)
        {
            AddEventListener(o.name, o._event.Invoke);
        }
    }

    public void InvokeEvent(string name)
    {
        events[name.ToLower()]?.Invoke();
    }

    public void AddEventListener(string name, EventAction action)
    {
        if (events.ContainsKey(name.ToLower()))
        {
            events[name.ToLower()] += action;
        }
        else
        {
            events.Add(name.ToLower(), action);
        } 
    }

    public void RemoveEventListener(string name, EventAction action)
    {
        events[name.ToLower()] -= action;
    }

}

[System.Serializable]
public class EventManagerInspectorHandler
{
    public List<UEvent> Events;

    List<UEvent> removedEventsCache = new List<UEvent>();
    int cacheDepth = 16;

    public void HookInspectorEventsToCharacterEvents(CharacterEvent[] events)
    {
        foreach(CharacterEvent e in events)
        {
            UnityEvent inspectorEvent = Events.Find(x => x.name == e.name)._event;
            e.AddEventListener(() => inspectorEvent?.Invoke());
        }
    }

    public void UpdateCharacterEvents(Character character, CharacterConfigManager config)
    {
        List<CharacterEvent> componentEvents = new List<CharacterEvent>();

        FindEventsInCompnents(character, config, ref componentEvents);
        FindEventsInCharacter(character, ref componentEvents);

        AddEventsToList(componentEvents);
        RemoveDuplicatedEvents(componentEvents);
        RemoveOldEvents(componentEvents);
        
    }
    void FindEventsInCompnents(Character character, CharacterConfigManager config, ref List<CharacterEvent> events)
    {
        CharacterComponent[] components = config.GetAllComponents();
        foreach (CharacterComponent o in components)
        {
            if (o is null) continue;

            CharacterEvent[] data = o.GetEvents();

            foreach(CharacterEvent e in data)
            {
                events.Add(e);
            }
        }
    }

    void FindEventsInCharacter(Character character, ref List<CharacterEvent> events)
    {
        FieldInfo[] characterClasses = character.GetType().GetFields().ToArray();
        foreach(FieldInfo o in characterClasses)
        {
            EventInfo[] classEvents = o.FieldType.GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach(EventInfo e in classEvents)
            {
                events.Add(new CharacterEvent(e.Name));
            }
        }
    }

    void AddEventsToList(List<CharacterEvent> events)
    {
        foreach(CharacterEvent e in events)
        {
            if (Events.Where(x => x.name == e.name).Count() > 0) continue;

            if (IsEventInCache(e.name))
            {
                Events.Add(FindEventInCache(e.name));
            }
            else
            {
                CreateNewInspectorEvent(e.name);
            }
           
           
        }
    }

    void RemoveOldEvents(List<CharacterEvent> events)
    {
        UEvent[] eventsToRemove = Events.Where(x => events.Find(y => y.name == x.name) is null).ToArray();
        
        foreach(UEvent e in eventsToRemove)
        {
            AddEventToCashe(e);
            Events.Remove(e);
        }
    }

    void RemoveDuplicatedEvents(List<CharacterEvent> events)
    {
        List<UEvent> eventsToRemove = new List<UEvent>();
        foreach(var e in events)
        {
            List<UEvent> eventsFound = Events.Where(x => x.name == e.name).ToList();
            eventsFound.RemoveAt(0);

            foreach(UEvent ue in eventsFound)
            {
                eventsToRemove.Add(ue);
            }
        }

        foreach(UEvent e in eventsToRemove)
        {
            Events.Remove(e);
        }
    }

    void CreateNewInspectorEvent(string name)
    {
        UEvent _event = new UEvent();
        _event.name = name;
        _event._event = new UnityEvent();

        Events.Add(_event);
    }
    bool IsEventInCache(string name)
    {
        return removedEventsCache.Where(x => x.name == name).Count() != 0;
    }

    UEvent FindEventInCache(string name)
    {
        return removedEventsCache.First(x => x.name == name);
    }
    void AddEventToCashe(UEvent e)
    {
        removedEventsCache.Add(e);

        if (removedEventsCache.Count() > cacheDepth)
        {
            removedEventsCache.RemoveAt(0);
        }
    }
}

[System.Serializable]
public struct UEvent
{
    public string name;
    public UnityEvent _event;
}

public class CharacterEvent
{
    public string name;

    EventAction _event;
    public CharacterEvent(string _name)
    {
        name = _name;
    }

    public void AddEventListener(EventAction action) => _event += action;
    public void RemoveEventListener(EventAction action) => _event -= action;

    void Invoke(Character _character)
    {
        _character.eventManager.InvokeEvent(name); 
    }
}

public delegate void EventAction();


