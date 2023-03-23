
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Stats Handler", menuName = "Character Components/Stats Handlers/Stats Handler")]
public class CharacterStatsHandler : CharacterStatHandler
{
    public override float GetStat(Stat[] stats, string name) => GetTargetStat(stats, name).value;
    public override void SetStat(Stat[] stats, string name, float value) => GetTargetStat(stats, name).value = value;
   
    public override void AddStatValue(Stat[] stats, string name, float amount)
    {
        Stat stat = GetTargetStat(stats, name);
        stat.value += amount;
    }
    public override void SubtractStatValue(Stat[] stats, string name, float amount)
    {
        Stat stat = GetTargetStat(stats, name);
        stat.value -= amount;
    }
    public override void MultiplyStatValue(Stat[] stats, string name, float amount)
    {
        Stat stat = GetTargetStat(stats, name);
        stat.value *= amount;
    }
    public override void DivideStatValue(Stat[] stats, string name, float amount)
    {
        Stat stat = GetTargetStat(stats, name);
        stat.value /= amount;
    }

    Stat GetTargetStat(Stat[] stats, string name)
    {
        return stats.First(x => x.name == name);
    }
}

[System.Serializable]
public class Stat
{
    public Stat(string _name, float _value)
    {
        name = _name;
        value = _value;
    }

    public string name;
    public float value;
}


