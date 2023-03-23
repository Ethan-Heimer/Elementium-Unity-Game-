using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterWallStatusInterfacer : CharacterComponentInterfacer<WallStatusProvider>
{
    public event Action OnWallEntered;
    public event Action OnWallExited;

    public CharacterWallStatusInterfacer(Character character, CharacterConfig config) : base(character, config) { }

    bool isOnWall;
    bool isBackTowardsWall;
    public void Tick()
    {
        bool onWall = GetCharacterComponent().CheckForWall(character);

        if (onWall && !character.groundStatus.IsOnGround() && !isOnWall)
        {
            OnWallEntered?.Invoke();
            isOnWall = true;
        }
        else if ((!onWall || character.groundStatus.IsOnGround()) && isOnWall)
        {
            OnWallExited?.Invoke();
            isOnWall = false;
        }

        isBackTowardsWall = GetCharacterComponent().CheckForBackTowordsWall(character);
    }

    public bool IsOnWall() => isOnWall;
    public bool IsBackTowardsWall() => isBackTowardsWall;

    public void DrawGizmos() => GetCharacterComponent().DrawGizmos(character); 
}
