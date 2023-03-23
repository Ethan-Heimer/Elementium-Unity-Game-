using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public abstract class GroundStatusProvider : CharacterComponent
{
    public abstract bool CheckForGround(Character character);
    public virtual void DrawGizmos(Character character) { }
}
