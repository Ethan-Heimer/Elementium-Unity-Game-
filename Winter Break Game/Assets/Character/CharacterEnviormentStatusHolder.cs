using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public abstract class CharacterEnviormentStatusHolder : CharacterComponent
{
    public abstract CharacterEnviormentStatusProvider[] GetStatusComponents();

    protected override CharacterEvent[] QuarryEvents()
    {
        CharacterEnviormentStatusProvider[] statuses = GetStatusComponents();
        List<CharacterEvent> events = new List<CharacterEvent>();

        foreach (CharacterEnviormentStatusProvider o in statuses)
        {
            CharacterEvent[] statusEvents = o.GetEvents();

            foreach (CharacterEvent e in statusEvents)
            {
                events.Add(e);
            }
        }

        return events.ToArray();
    }
}
