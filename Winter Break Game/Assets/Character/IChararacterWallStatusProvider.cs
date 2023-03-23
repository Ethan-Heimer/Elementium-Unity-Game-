using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
public abstract class WallStatusProvider : CharacterComponent
{
    public abstract bool CheckForWall(Character character);
    public abstract bool CheckForBackTowordsWall(Character character);
    public virtual void DrawGizmos(Character character) { }
}
