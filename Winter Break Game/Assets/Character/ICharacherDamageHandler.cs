using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterDamageHandler : CharacterComponent
{
    public abstract void OnDamaged(Character character);
}
