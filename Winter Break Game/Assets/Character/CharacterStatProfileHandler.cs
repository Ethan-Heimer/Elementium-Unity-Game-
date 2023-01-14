using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatProfileHandler : CharacterClass, ICharacterStatsHandler
{
    public StatProfile statProfile;

    public float GetStat(string name) => statProfile.GetStat(name).GetValue();
    public void SetStat(string name, float value) => statProfile.GetStat(name).SetValue(value);
    public void ResetStatValue(string name) => statProfile.GetStat(name).ResetStatValue();

    public void DecreaseStatValue(string name)
    {
        Stat stat = statProfile.GetStat(name);
        stat.SetValue(stat.GetValue() - 1);
    }

    public void IncreaseStatValue(string name)
    {
        Stat stat = statProfile.GetStat(name);
        stat.SetValue(stat.GetValue() + 1);
    }
}
