using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public abstract class GroundStatusProvider : CharacterClass
{
    public abstract bool IsOnGround();

    public event Action OnHitGround;
    public event Action OnEnterAir;

    bool isOnGround; 
    public void Tick()
    {
        if (character.climbStatus.IsClimbing()) return;
        if (character.wallStatus.IsOnWall() && !IsOnGround()) return;

        if(IsOnGround() && !isOnGround)
        {
            OnHitGround?.Invoke();
            isOnGround = true;
        }
        else if(!IsOnGround() && isOnGround)
        {
            OnEnterAir?.Invoke();
            isOnGround = false; 
        }
    }

    public virtual void DrawGizmos() { }
}
