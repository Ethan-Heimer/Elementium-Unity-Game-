using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterClimbStatusInterfacer : CharacterComponentInterfacer<ClimbStatusProvider>
{
    public event Action OnClimbEnter;
    public event Action OnClimbExit;

    public CharacterClimbStatusInterfacer(Character character, CharacterConfig characterConfig) : base(character, characterConfig) { }

    bool isClimbing;
    protected Timer climbCooldown = new Timer(.5f);
    public void Tick()
    {
        if (!climbCooldown.IsTimerUp()) return;

        bool canClimb = GetCharacterComponent().CheckForClimb(character);

        if (canClimb && character.input.GetClimbInput() && !isClimbing)
        {
            OnClimbEnter?.Invoke();
            isClimbing = true;
        }
        else if ((!canClimb || character.input.GetJumpInput()) && isClimbing)
        {
            OnClimbExit?.Invoke();
            isClimbing = false;

            climbCooldown.ResetTimer();
        }
    }

    public bool IsClimbing() => isClimbing;
}
