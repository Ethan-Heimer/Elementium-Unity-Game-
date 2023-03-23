using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterDamageChecker : CharacterComponent
{
    public abstract bool CheckDamage(Character character); 
}
