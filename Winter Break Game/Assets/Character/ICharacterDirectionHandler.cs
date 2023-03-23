using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class CharacterDirectionHandler : CharacterComponent
{
    public abstract void FlipCharacter(Character character, SpriteRenderer spriteRenderer, float Direction);
    public abstract int GetCurrentDirection(Character character, SpriteRenderer spriteRenderer);

    public virtual void Start() { }
}
