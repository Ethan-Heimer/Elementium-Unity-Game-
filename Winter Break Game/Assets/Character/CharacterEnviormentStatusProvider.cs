using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

public abstract class CharacterEnviormentStatusProvider : CharacterComponent
{
    public event Action<Character> OnTrue;
    public event Action<Character> OnFalse;

    bool statusInovked;
    public bool CheckStatus(Character character)
    {
        bool value = GetEnviormentStatus(character);

        if (statusInovked)
            InvokeEvents(value, character);
        else
            statusInovked = true;

        return value;
    }

    protected abstract bool GetEnviormentStatus(Character character);
   
    public abstract string GetStatusName();
    //public virtual bool CheckInverseEnviormentStatus(Character character)
    public virtual void DrawGizmos(Character character) { }

    void InvokeEvents(bool value, Character character)
    {
        if (!statusInovked) return;

        if (value && !character.enviormentStatuses.GetStatus(GetStatusName()))
        {
            OnTrue?.Invoke(character);
           
        }
        else if (!value && character.enviormentStatuses.GetStatus(GetStatusName()))
        {
            OnFalse?.Invoke(character);
        }
    }

    protected override CharacterEvent[] QuarryEvents()
    {
        EventInfo[] eventInfos = this.GetType().GetEvents()?.Where(x => x.EventHandlerType == typeof(Action<Character>)).ToArray();
        CharacterEvent[] events = new CharacterEvent[eventInfos.Length];

        for (int i = 0; i < eventInfos.Length; i++)
        {
            CharacterEvent e = new CharacterEvent(GetStatusName()+eventInfos[i].Name);

            MethodInfo invokeEvent = e.GetType().GetMethod("Invoke", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            Delegate eventInvoker = Delegate.CreateDelegate(eventInfos[i].EventHandlerType, e, invokeEvent);

            eventInfos[i].AddEventHandler(this, eventInvoker);

            events[i] = e;
        }

        return events;
    }
}