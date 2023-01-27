using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatProfileHandler : CharacterClass, ICharacterStatsHandler
{
    public StatProfile statProfile;

    public float GetStat(string name) => statProfile.GetStat(name).GetValue();
    public void SetStat(string name, float value) => statProfile.GetStat(name).SetValue(value);
    public void ResetStatValue(string name) => statProfile.GetStat(name).ResetStatValue();

    public void InitAllValues()
    {
        foreach(Stat o in statProfile.stats)
        {
            o.ResetStatValue();
        }
    }

    public void AddStatValue(string name, float amount)
    {
        Stat stat = statProfile.GetStat(name);
        stat.SetValue(stat.GetValue() + amount); 
    }
    public void SubtractStatValue(string name, float amount)
    {
        Stat stat = statProfile.GetStat(name);
        stat.SetValue(stat.GetValue() - amount); 
    }
    public void MultiplyStatValue(string name, float amount)
    {
        Stat stat = statProfile.GetStat(name);
        stat.SetValue(stat.GetValue() * amount); 
    }
    public void DivideStatValue(string name, float amount)
    {
        Stat stat = statProfile.GetStat(name);
        stat.SetValue(stat.GetValue() / amount); 
    }

    public void AddStatValueFromBase(string name, float amount)
    {
        Stat stat = statProfile.GetStat(name);
        stat.SetValue(stat.GetBaseValue() + amount);
    }
    public void SubtractStatValueFromBase(string name, float amount)
    {
        Stat stat = statProfile.GetStat(name);
        stat.SetValue(stat.GetBaseValue() - amount);
    }
    public void MultiplyStatValueFromBase(string name, float amount)
    {
        Stat stat = statProfile.GetStat(name);
        stat.SetValue(stat.GetBaseValue() * amount);
    }
    public void DivideStatValueFromBase(string name, float amount)
    {
        Stat stat = statProfile.GetStat(name);
        stat.SetValue(stat.GetBaseValue() / amount);
    }


}
