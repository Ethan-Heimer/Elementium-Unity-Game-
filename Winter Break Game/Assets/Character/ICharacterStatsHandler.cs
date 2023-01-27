using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterStatsHandler : ICharacterInterface
{
    public float GetStat(string name);
    public void SetStat(string name, float value);

    public void ResetStatValue(string name);
    public void InitAllValues();

    public void AddStatValue(string name, float amount);
    public void SubtractStatValue(string name, float amount);
    public void MultiplyStatValue(string name, float amount);
    public void DivideStatValue(string name, float amount);

    public void AddStatValueFromBase(string name, float amount);
    public void SubtractStatValueFromBase(string name, float amount);
    public void MultiplyStatValueFromBase(string name, float amount);
    public void DivideStatValueFromBase(string name, float amount); 
}
