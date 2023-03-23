using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStatHandler : CharacterComponent
{
    [SerializeField] Stat[] stats;
    public Stat[] GetStats() => stats;

    public abstract float GetStat(Stat[] stats, string name);
    public abstract void SetStat(Stat[] stats, string name, float value);
          
    public abstract void AddStatValue(Stat[] stats, string name, float amount);
    public abstract void SubtractStatValue(Stat[] stats, string name, float amount);
    public abstract void MultiplyStatValue(Stat[] stats, string name, float amount);
    public abstract void DivideStatValue(Stat[] stats, string name, float amount);
}