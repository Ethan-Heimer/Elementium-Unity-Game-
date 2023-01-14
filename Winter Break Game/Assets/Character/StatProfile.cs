using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu]
public class StatProfile : ScriptableObject
{
    public Stat[] stats;

    public Stat GetStat(string name) => stats.First(x => x.GetName() == name);
    
}
