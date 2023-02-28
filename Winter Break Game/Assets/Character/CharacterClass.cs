using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass{
    protected Character character;

    public virtual void Constructer(Character _character)
    {
        character = _character;
    }

    public virtual object Clone() => MemberwiseClone();
}