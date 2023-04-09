using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

public abstract class CharacterComponent : ScriptableObject
{
    public virtual void OnStart(Character character) {}

    CharacterEvent[] characterEvents;
    public CharacterEvent[] GetEvents()
    {

        if (characterEvents is not null) return characterEvents;

        return QuarryEvents();
    }

    protected virtual CharacterEvent[] QuarryEvents()
    {
        EventInfo[] eventInfos = this.GetType().GetEvents()?.Where(x => x.EventHandlerType == typeof(Action<Character>)).ToArray();
        CharacterEvent[] events = new CharacterEvent[eventInfos.Length];

        for (int i = 0; i < eventInfos.Length; i++)
        {
            CharacterEvent e = new CharacterEvent(eventInfos[i].Name);

            MethodInfo invokeEvent = e.GetType().GetMethod("Invoke", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            Delegate eventInvoker = Delegate.CreateDelegate(eventInfos[i].EventHandlerType, e, invokeEvent);

            eventInfos[i].AddEventHandler(this, eventInvoker);

            events[i] = e;
        }

        return events;
    }
}


