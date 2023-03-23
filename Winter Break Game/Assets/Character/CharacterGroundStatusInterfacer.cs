using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterGroundStatusInterfacer : CharacterComponentInterfacer<GroundStatusProvider>
{
    public event Action OnHitGround;
    public event Action OnEnterAir;

    public CharacterGroundStatusInterfacer(Character _character, CharacterConfig config) : base(_character, config) { }

    bool isOnGround;
    public void Tick()
    {
        if (character.climbStatus.IsClimbing()) return;

        if (GetCharacterComponent().CheckForGround(character) && !isOnGround)
        {
            OnHitGround?.Invoke();
            isOnGround = true;
        }
        else if (!GetCharacterComponent().CheckForGround(character) && isOnGround)
        {
            OnEnterAir?.Invoke();
            isOnGround = false;
        }
    }

    public bool IsOnGround() => isOnGround;

    public void DrawGizmos() => GetCharacterComponent().DrawGizmos(character);
}
