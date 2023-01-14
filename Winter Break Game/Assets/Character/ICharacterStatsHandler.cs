using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterStatsHandler : ICharacterInterface
{
    public float GetStat(string name);
    public void SetStat(string name, float value);
    public void ResetStatValue(string name);

    public void DecreaseStatValue(string name);
    public void IncreaseStatValue(string name);
}
