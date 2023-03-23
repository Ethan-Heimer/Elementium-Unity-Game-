using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class CharacterStatsHandlerInterfacer : CharacterComponentInterfacer<>
{
    Stat[] stats;
    public CharacterStatsHandlerInterfacer(Character character, CharacterConfig config) : base(character, config)
    {
        stats = new Stat[statsComponent.GetStats().Length];
        for(int i = 0; i < stats.Length; i++)
        {
            Stat currentStat = statsComponent.GetStats()[i];
            stats[i] = new Stat(currentStat.name, currentStat.value);
        }
    }

    public float GetStat(string name) => statsComponent.GetStat(stats, name);
    public void SetStat(string name, float value) => statsComponent.SetStat(stats, name, value);

    public void AddStatValue(string name, float amount) => statsComponent.AddStatValue(stats, name, amount);
    public void SubtractStatValue(string name, float amount) => statsComponent.SubtractStatValue(stats, name, amount);
    public void MultiplyStatValue(string name, float amount) => statsComponent.MultiplyStatValue(stats, name, amount);
    public void DivideStatValue(string name, float amount) => statsComponent.DivideStatValue(stats, name, amount);

}

*/