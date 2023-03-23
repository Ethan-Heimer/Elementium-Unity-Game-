using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CharacterComponent : ScriptableObject
{
    public virtual void OnStart(Character character) { }
}

