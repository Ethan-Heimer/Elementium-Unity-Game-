using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public abstract class GroundStatusProvider : CharacterClass
{
    protected abstract bool CheckForGround();

    public event Action OnHitGround;
    public event Action OnEnterAir;

    bool isOnGround; 
    public void Tick()
    {
        if (character.climbStatus.IsClimbing()) return;

        if(CheckForGround() && !isOnGround)
        {
            OnHitGround?.Invoke();
            isOnGround = true;
        }
        else if(!CheckForGround() && isOnGround)
        {
            OnEnterAir?.Invoke();
            isOnGround = false; 
        }
    }

    public bool IsOnGround() => isOnGround;

    public virtual void DrawGizmos() { }
}
