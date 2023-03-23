using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterActionHandler : CharacterComponent
{
    public abstract void OnAction(Character character);
}
