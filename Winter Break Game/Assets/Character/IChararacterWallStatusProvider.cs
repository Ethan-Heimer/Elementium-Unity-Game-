using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
public abstract class WallStatusProvider : CharacterClass
{
    public event Action OnWallEntered;
    public event Action OnWallExited;

    protected abstract bool CheckForWall();
    protected abstract bool CheckForBackTowordsWall();

    bool isOnWall;
    bool isBackTowardsWall; 
    public void Tick()
    {
        bool onWall = CheckForWall();

        if(onWall && !character.groundStatus.IsOnGround() && !isOnWall)
        {
            OnWallEntered?.Invoke();
            isOnWall = true;
        }
        else if((!onWall || character.groundStatus.IsOnGround()) && isOnWall)
        {
            OnWallExited?.Invoke();
            isOnWall = false; 
        }

        isBackTowardsWall = CheckForBackTowordsWall();
    }

    public bool IsOnWall() => isOnWall;
    public bool IsBackTowardsWall() => isBackTowardsWall;

    public virtual void DrawGizmos() { }
}
