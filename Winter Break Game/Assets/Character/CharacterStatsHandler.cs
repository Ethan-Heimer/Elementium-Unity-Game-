using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class CharacterStatsHandler : CharacterClass, ICharacterStatsHandler
{
    [SerializeField] Stat[] stats;

    public float GetStat(string name) => stats.First(x => x.GetName() == name).GetValue();
    public void SetStat(string name, float value) => stats.First(x => x.GetName() == name).SetValue(value);
    public void ResetStatValue(string name) => stats.First(x => x.GetName() == name).ResetStatValue();

    public void DecreaseStatValue(string name)
    {
        Stat stat = stats.First(x => x.GetName() == name);
        stat.SetValue(stat.GetValue() - 1); 
    }

    public void IncreaseStatValue(string name)
    {
        Stat stat = stats.First(x => x.GetName() == name);
        stat.SetValue(stat.GetValue() + 1);
    }
}

[System.Serializable]
public class Stat
{
    [SerializeField] string name;
    [SerializeField] float startValue;

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

    public float SetValue(float _value) => value = _value;
    public void ResetStatValue() => value = startValue; 
    

}


