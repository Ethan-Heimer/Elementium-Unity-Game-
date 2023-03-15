using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
public abstract class WallStatusProvider : CharacterClass
{
    public event Action OnWallEntered;
    public event Action OnWallExited; 
    public abstract bool IsOnWall();
    public abstract bool IsBackTowordsWall();
    bool isOnWall;
    public void Tick()
    {
        if(IsOnWall() && !character.groundStatus.IsOnGround() && !isOnWall)
        {
            OnWallEntered?.Invoke();
            isOnWall = true;
        }
        else if((!IsOnWall() || character.groundStatus.IsOnGround()) && isOnWall)
        {
            OnWallExited?.Invoke();
            isOnWall = false; 
        }
    }

    public virtual void DrawGizmos() { }
}
