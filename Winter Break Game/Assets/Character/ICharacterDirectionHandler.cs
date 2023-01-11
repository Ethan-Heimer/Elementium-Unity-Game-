using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface ICharacterDirectionHandler : ICharacterInterface
{
    void FlipCharacter(int Direction);
    int GetCurrentDirection();
}
