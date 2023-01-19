using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu]
public class StatProfile : ScriptableObject
{
    public Stat[] stats;

    public void Awake()
    {
        ResetStats();
    }

    public void OnValidate()
    {
        ResetStats();
    }

    void ResetStats()
    {
        foreach (Stat o in stats)
        {
            o.ResetStatValue();
        }
    }

    public Stat GetStat(string name) => stats.First(x => x.GetName() == name);
    
}
