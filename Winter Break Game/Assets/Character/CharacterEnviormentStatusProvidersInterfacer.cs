using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnviormentStatusProvidersInterfacer : CharacterComponentInterfacer<CharacterEnviormentStatusHolder>
{
    Dictionary<string, bool> statusValues = new Dictionary<string, bool>();
    public CharacterEnviormentStatusProvidersInterfacer(Character character, CharacterConfigManager config) : base(character, config) { }

    public void CheckStatuses()
    {
        CharacterEnviormentStatusProvider[] statuses = Component.GetStatusComponents();

        foreach(CharacterEnviormentStatusProvider o in statuses)
        {
            bool value = o.CheckStatus(character);

            string statusName = o.GetStatusName();
            if (!statusValues.ContainsKey(statusName))
            {
                statusValues.Add(statusName, value);
                continue;
            }

            statusValues[statusName] = value;
        }
    }

    public bool GetStatus(string name)
    {
        try
        {
            return statusValues[name];
        }
        catch
        {
            Debug.LogWarning("Status: " + name + " Does Not Exist");
            return false;
        }
       
    }

    public void DrawGizmos()
    {
        CharacterEnviormentStatusProvider[] statuses = Component.GetStatusComponents();
        foreach (CharacterEnviormentStatusProvider o in statuses)
        {
            o.DrawGizmos(character);
        }
    }
}
