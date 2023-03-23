using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMovementHandler : CharacterComponent
{
    public abstract void OnStart(Character character);
    public abstract void OnUpdate(Character character);
    public abstract void OnFixedUpdate(Character character); 
}
