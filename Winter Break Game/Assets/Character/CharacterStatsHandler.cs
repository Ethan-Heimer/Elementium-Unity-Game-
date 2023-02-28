using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class CharacterStatsHandler : CharacterClass, ICharacterStatsHandler
{
    public Stat[] stats = new Stat[0];

    public float GetStat(string name) => GetTargetStat(name).GetValue();
    public void SetStat(string name, float value) => GetTargetStat(name).SetValue(value);
    public void ResetStatValue(string name) => GetTargetStat(name).ResetStatValue();
    public void InitAllValues()
    {
        foreach(Stat o in stats)
        {
            o.ResetStatValue();
        }
    }

    public void AddStatValue(string name, float amount)
    {
        Stat stat = GetTargetStat(name);
        stat.SetValue(stat.GetValue() + amount);
    }
    public void SubtractStatValue(string name, float amount)
    {
        Stat stat = GetTargetStat(name);
        stat.SetValue(stat.GetValue() - amount);
    }
    public void MultiplyStatValue(string name, float amount)
    {
        Stat stat = GetTargetStat(name);
        stat.SetValue(stat.GetValue() * amount);
    }
    public void DivideStatValue(string name, float amount)
    {
        Stat stat = GetTargetStat(name);
        stat.SetValue(stat.GetValue() / amount);
    }

    public void AddStatValueFromBase(string name, float amount)
    {
        Stat stat = GetTargetStat(name);
        stat.SetValue(stat.GetBaseValue() + amount);
    }
    public void SubtractStatValueFromBase(string name, float amount)
    {
        Stat stat = GetTargetStat(name);
        stat.SetValue(stat.GetBaseValue() - amount);
    }
    public void MultiplyStatValueFromBase(string name, float amount)
    {
        Stat stat = GetTargetStat(name);
        stat.SetValue(stat.GetBaseValue() * amount);
    }
    public void DivideStatValueFromBase(string name, float amount)
    {
        Stat stat = GetTargetStat(name);
        stat.SetValue(stat.GetBaseValue() / amount);
    }

    Stat GetTargetStat(string name)
    {
        try
        {
            return stats.First(x => x.GetName() == name);
        }
        catch (System.InvalidOperationException)
        {
            Debug.LogError(name + " Is Not A Stat"); 
        }

        return null;
       
    }

    public override object Clone()
    {
        CharacterStatsHandler obj = (CharacterStatsHandler)this.MemberwiseClone();
        obj.stats = new Stat[stats.Length];

        for(int i = 0; i < stats.Length; i++)
        {
            obj.stats[i] = new Stat();

            obj.stats[i].name = stats[i].name;
            obj.stats[i].startValue = stats[i].startValue;

            obj.stats[i].ResetStatValue();
        }

        return obj as object;
    }

}

[System.Serializable]
public class Stat
{
    public string name;
    public float startValue;

    float value;
    bool initiated = false;

    public string GetName() => name; 

    public float GetValue()
    {
        if (!initiated)
        {
            ResetStatValue();
            initiated = true; 
        }

        return value; 
    }

    public float GetBaseValue() => startValue;

    public void SetValue(float _value) => value = _value; 
    public void ResetStatValue() => value = startValue; 
    

}


