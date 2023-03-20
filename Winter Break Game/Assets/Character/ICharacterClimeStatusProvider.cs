using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public abstract class ClimbStatusProvider : CharacterClass
{
    protected abstract bool CheckForClimb();

    public event Action OnClimbEnter;
    public event Action OnClimbExit; 

    bool isClimbing;
    protected Timer climbCooldown = new Timer(.5f);  
    public void Tick()
    {
        if (!climbCooldown.IsTimerUp()) return;

        bool canClimb = CheckForClimb();

        if(canClimb && character.input.GetClimbInput() && !isClimbing)
        {
            OnClimbEnter?.Invoke();
            isClimbing = true;
        }
        else if((!canClimb || character.input.GetJumpInput()) && isClimbing)
        {
            OnClimbExit?.Invoke();
            isClimbing = false;

            climbCooldown.ResetTimer();
        }
    }

    public bool IsClimbing() => isClimbing;
}
